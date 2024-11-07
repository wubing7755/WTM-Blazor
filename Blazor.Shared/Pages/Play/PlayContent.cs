using Blazor.Shared.Pages.Play.Item.GL;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using WtmBlazorUtils;

namespace Blazor.Shared.Pages.Play;

public class PlayContent:ComponentBase
{
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {

        builder.OpenElement(0, "div");
        builder.OpenComponent<Draw>(1);
        builder.CloseComponent();
        builder.CloseElement();
        
        base.BuildRenderTree(builder);
    }
}