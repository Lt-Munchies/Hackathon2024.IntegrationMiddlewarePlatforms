using Flurl.Http;
using Hackathorn2024.Server.Models;

namespace Hackathorn2024.Server.Clients;

internal class InvestecClient : BaseHttpClient, IInvestecClient
{
    public InvestecClient(ILogger<InvestecClient> logger, HttpClient client) : base(logger, client)
    {
    }

    public async Task<AccountResponse> GetAccountAsync(CancellationToken token = default)
    {
        return await WrapRetryRequestAsync(async client =>
        {
            var request = client.WithHeader("Content-Type", "application/json")
                .Request()
                .AppendPathSegment("v1")
                .AppendPathSegment("accounts");

            return await request.GetJsonAsync<AccountResponse>(cancellationToken: token);
        });
    }
}
