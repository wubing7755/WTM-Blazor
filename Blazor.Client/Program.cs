﻿using System.Globalization;
using System.Threading.Tasks;
using Blazor.Shared.Core.Utils;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using WalkingTec.Mvvm.Core;
using WtmBlazorUtils;

namespace Blazor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            var configs = builder.Configuration.Get<Configs>();
            builder.RootComponents.Add<Shared.App>("app");
            builder.Services.AddLocalization(option => option.ResourcesPath = "Resources");
            builder.Services.AddBootstrapBlazor(null, options => { options.ResourceManagerStringLocalizerType = typeof(Shared.Program); });
            builder.Services.AddWtmBlazor(configs, builder.HostEnvironment.BaseAddress);
            
            // 添加自定义服务
            builder.Services.AddServices();  
            
            var host = builder.Build();
            var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
            var result = await jsInterop.InvokeAsync<string>("localStorageFuncs.get", "wtmculture");
            
            CultureInfo culture = null;
            if (result == null)
            {
                culture = configs.SupportLanguages[0];
            }
            else 
            {
                culture = new CultureInfo(result);
            }
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            await host.RunAsync();
        }

    }
}
