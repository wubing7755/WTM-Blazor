using Blazor.ViewModel.Play;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
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
        builder.AddAttribute(8, "style", "background-color:gray;");
        builder.CloseElement();
        
        // Button 按钮 - 添加用户
        builder.OpenElement(9, "button");
        builder.AddAttribute(10, "style", "width:60px;height:30px;background-color:yellow;");
        
        // onclick 事件
        builder.AddAttribute(11, "onclick", EventCallback.Factory.Create(this, AddPlayerInfo));
        builder.AddContent(12, "Post请求");
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
            AddPlayerInfo();
        }
    }

    private async void AddPlayerInfo()
    {
        string url = "api/PlayerInfo/AddPlayer";

        // 创建 PlayerVM 对象
        var player = new PlayerVM
        {
            Name = "Alice", // 你可以根据需要传递动态值
            IsValid = false
        };


        await WtmBlazor.Api.CallAPI(url, HttpMethodEnum.POST, player);
    }
}