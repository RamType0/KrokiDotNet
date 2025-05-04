using Kroki;
using Kroki.DependencyInjection;
using Microsoft.Extensions.Options;

#pragma warning disable IDE0130 // Namespace がフォルダー構造と一致しません
namespace Microsoft.Extensions.DependencyInjection;
#pragma warning restore IDE0130 // Namespace がフォルダー構造と一致しません

public static class KrokiExtensions
{
    public static OptionsBuilder<KrokiHttpRequestFactoryOptions> AddKrokiHttpRequestFactory(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        services.Add(new(
            serviceType: typeof(KrokiHttpRequestFactory),
            factory: services =>
            {
                var options = lifetime switch
                {
                    ServiceLifetime.Scoped => services.GetRequiredService<IOptionsSnapshot<KrokiHttpRequestFactoryOptions>>().Value,
                    _ => services.GetRequiredService<IOptionsMonitor<KrokiHttpRequestFactoryOptions>>().CurrentValue,
                };
                return new KrokiHttpRequestFactory(options.Endpoint);
            },
        lifetime: lifetime));
        return services.AddOptions<KrokiHttpRequestFactoryOptions>();
    }
}
