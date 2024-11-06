using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using WtmBlazorUtils;

namespace Blazor.Shared.Pages.Play.Item.GL;

public class Draw : BasePage
{
    public RenderFragment RenderChild()
    {
        return builder => RenderItem(builder);
    }

    private void RenderItem(RenderTreeBuilder builder)
    {
        // 最上层div
        builder.OpenElement(0, "div");
        builder.AddAttribute(1, "class", "item");
        
        builder.OpenElement(2, "p");
        builder.AddContent(3, "This is a canvas.");
        builder.CloseElement();
        
        // canvas元素
        builder.OpenElement(4, "canvas");
        builder.AddAttribute(5, "id", "webGPUCanvas");
        builder.AddAttribute(6, "width", "1200");
        builder.AddAttribute(7, "height", "600");
        builder.CloseElement();
        
        builder.CloseElement();
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            JSRuntime.InvokeVoidAsync("drawBackGround", "webGPUCanvas");
        }
    }

}