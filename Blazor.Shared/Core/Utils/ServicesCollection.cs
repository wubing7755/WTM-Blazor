using Blazor.Shared.Pages.Play;
using Blazor.Shared.Pages.Play.Item.GL;
using Microsoft.Extensions.DependencyInjection;
using WtmBlazorUtils;

namespace Blazor.Shared.Core.Utils;

/// <summary>
/// 核心服务
/// </summary>
public static class ServicesCollection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        
        // services.AddScoped<Draw>();
        // services.AddScoped<PlayContent>();
        
        return services;
    }
}