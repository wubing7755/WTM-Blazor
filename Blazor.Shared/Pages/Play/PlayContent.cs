using Blazor.Shared.Pages.Play.Item.GL;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using WtmBlazorUtils;

namespace Blazor.Shared.Pages.Play;

public class PlayContent:BasePage
{
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {

        Draw draw = new Draw();
        
        builder.OpenElement(0, "div");
        builder.AddContent(1, draw.RenderChild());
        builder.CloseElement();
        
        builder.OpenComponent(0, typeof(Draw));
        builder.CloseComponent();
        
        base.BuildRenderTree(builder);
    }
}