using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using WtmBlazorUtils;

namespace Blazor.Shared.Pages.Play.Item.GL;

public class Draw : BasePage
{
    private static readonly IJSRuntime _jsRuntime;
    
    public static RenderFragment RenderChild()
    {
        return builder => RenderItem(builder);
    }

    public static void RenderItem(RenderTreeBuilder builder)
    {
        // 最上层div
        builder.OpenElement(0, "div");
        builder.AddAttribute(1, "class", "item");
        builder.AddContent(2, "This is a canvas.");
        
        // canvas元素
        builder.OpenElement(3, "canvas");
        builder.AddAttribute(4, "id", "webGPUCanvas");
        builder.AddAttribute(5, "width", "1200");
        builder.AddAttribute(6, "height", "600");
        builder.CloseElement();
        
        // 调用JavaScript方法
        _jsRuntime.InvokeVoidAsync("draw", "webGPUCanvas");
        
        builder.CloseElement();
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        
    }
}