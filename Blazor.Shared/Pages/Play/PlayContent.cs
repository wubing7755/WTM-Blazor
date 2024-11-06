using Blazor.Shared.Pages.Play.Item.GL;
using Microsoft.AspNetCore.Components.Rendering;
using WtmBlazorUtils;

namespace Blazor.Shared.Pages.Play;

public class PlayContent:BasePage
{
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "div");
        builder.AddContent(1, Draw.RenderChild());
        builder.CloseElement();
        
        base.BuildRenderTree(builder);
    }
}