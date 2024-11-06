using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using WtmBlazorUtils;

namespace Blazor.Shared.Pages.Play.Item.GL;

public class Draw : BasePage
{
    public static RenderFragment RenderChild()
    {
        return builder => RenderItem(builder);
    }

    public static void RenderItem(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "div");
        builder.AddAttribute(1, "class", "item");
        builder.AddContent(2, "hello");
        builder.CloseElement();
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        
    }
}