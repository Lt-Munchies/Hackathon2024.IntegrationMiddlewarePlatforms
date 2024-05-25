using Flurl;
using Flurl.Http;
using Hackathorn2024.Server.Models;
using Hackathorn2024.Server.Options;
using Microsoft.Extensions.Options;

namespace Hackathorn2024.Server.Clients;

internal class InvestecClient(ILogger<InvestecClient> logger, IOptions<InvestecClientOptions> options, HttpClient client)
    : BaseHttpClient(logger, client), IInvestecClient
{
    public async Task<GetAccountsResponse> GetAccountsAsync(CancellationToken token = default)
    {
        return await WrapRetryRequestAsync(async client =>
        {
            var request = client.WithHeader("Content-Type", "application/json")
                .Request();

            request.Url = new Url(options.Value.Api)
                .AppendPathSegment("za")
                .AppendPathSegment("pb")
                .AppendPathSegment("v1")
                .AppendPathSegment("accounts");

            return await request.GetJsonAsync<GetAccountsResponse>(cancellationToken: token);
        });
    }
}
