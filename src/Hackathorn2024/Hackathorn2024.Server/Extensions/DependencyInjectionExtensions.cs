using Hackathorn2024.Server.Clients;
using Hackathorn2024.Server.Options;
using Microsoft.Extensions.Options;

namespace Hackathorn2024.Server.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddInvestecClient(this IServiceCollection services, IConfiguration configuration)
    {
        if (services.All(x => x.ServiceType != typeof(IConfigureOptions<InvestecClientOptions>)))
            services.AddOptions<InvestecClientOptions>().BindConfiguration(nameof(InvestecClientOptions));

        services.AddHttpClient<IInvestecClient, InvestecClient>();

        return services;
    }

    public static IServiceCollection AddPdfChatClient(this IServiceCollection services, IConfiguration configuration)
    {
        if (services.All(x => x.ServiceType != typeof(IConfigureOptions<PdfChatClientOptions>)))
            services.AddOptions<PdfChatClientOptions>().BindConfiguration(nameof(PdfChatClientOptions));

        services.AddHttpClient<IPdfChatClient, PdfClient>();

        return services;
    }
}
