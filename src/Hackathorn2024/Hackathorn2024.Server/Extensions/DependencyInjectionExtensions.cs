using Hackathorn2024.Server.Options;
using Microsoft.Extensions.Options;

namespace Hackathorn2024.Server.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddAccountClient(this IServiceCollection services, IConfiguration configuration)
    {
        if (services.All(x => x.ServiceType != typeof(IConfigureOptions<InvestecClientOptions>)))
            services.AddOptions<InvestecClientOptions>().BindConfiguration(nameof(InvestecClientOptions));

        return services;
    }
}
