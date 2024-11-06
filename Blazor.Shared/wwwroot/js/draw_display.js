async function draw(canvasId)
{
    if (!navigator.gpu) {
        alert("WebGPU is not supported by this browser.");
        return;
    }

    const canvas = document.getElementById(canvasId);
    const context = canvas.getContext("webgpu");

    // 配置 WebGPU 渲染器
    const adapter = await navigator.gpu.requestAdapter();
    const device = await adapter.requestDevice();

    context.configure({
        device: device,
        format: "bgra8unorm"
    });

    // 创建顶点着色器和片段着色器
    const vertexShaderCode = `
    @stage(vertex)
    fn main(@location(0) position: vec4<f32>) -> @builtin(position) vec4<f32> {
        return position;
    }
`;

    const fragmentShaderCode = `
    @stage(fragment)
    fn main(@builtin(position) fragCoord: vec4<f32>) -> @location(0) vec4<f32> {
        let radius: f32 = 0.5;
        let dist: f32 = length(fragCoord.xy);
        
        if (dist < radius) {
            return vec4<f32>(1.0, 0.0, 0.0, 1.0);  // 红色圆
        } else {
            return vec4<f32>(0.0, 0.0, 0.0, 0.0);  // 背景色
        }
    }
`;

    const vertexShaderModule = device.createShaderModule({ code: vertexShaderCode });
    const fragmentShaderModule = device.createShaderModule({ code: fragmentShaderCode });

    // 创建渲染管线
    const pipeline = device.createRenderPipeline({
        vertex: {
            module: vertexShaderModule,
            entryPoint: "main",
            buffers: [{
                arrayStride: 4 * 4,
                attributes: [{
                    format: "float4",
                    offset: 0,
                    shaderLocation: 0
                }]
            }]
        },
        fragment: {
            module: fragmentShaderModule,
            entryPoint: "main",
            targets: [{
                format: "bgra8unorm"
            }]
        },
        primitive: {
            topology: "triangle-strip",
        }
    });

    // 创建顶点缓冲区（用于圆形）
    const vertexData = new Float32Array([
        0.0, 0.0, 0.0, 1.0,  // 圆心
        1.0, 0.0, 0.0, 1.0,  // 点1
        -1.0, 0.0, 0.0, 1.0,  // 点2
        0.0, 1.0, 0.0, 1.0,  // 点3
        0.0, -1.0, 0.0, 1.0  // 点4
    ]);

    const vertexBuffer = device.createBuffer({
        size: vertexData.byteLength,
        usage: GPUBufferUsage.VERTEX | GPUBufferUsage.COPY_DST,
        mappedAtCreation: true
    });

    new Float32Array(vertexBuffer.getMappedRange()).set(vertexData);
    vertexBuffer.unmap();

    // 创建渲染目标
    const renderPassDescriptor = {
        colorAttachments: [{
            view: context.getCurrentTexture().createView(),
            loadValue: { r: 0, g: 0, b: 0, a: 1 },  // 背景色为黑色
            storeOp: "store",
        }]
    };

    // 创建渲染命令
    const commandEncoder = device.createCommandEncoder();
    const passEncoder = commandEncoder.beginRenderPass(renderPassDescriptor);

    passEncoder.setPipeline(pipeline);
    passEncoder.setVertexBuffer(0, vertexBuffer);
    passEncoder.draw(4, 1);  // 画 4 个顶点（四个坐标）

    passEncoder.endPass();

    const commandBuffer = commandEncoder.finish();
    device.queue.submit([commandBuffer]);
}
