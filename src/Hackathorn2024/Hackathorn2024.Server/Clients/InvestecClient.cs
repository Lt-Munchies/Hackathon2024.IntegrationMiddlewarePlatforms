using Flurl;
using Flurl.Http;
using Hackathorn2024.Server.Models;
using Hackathorn2024.Server.Options;
using Microsoft.Extensions.Options;

namespace Hackathorn2024.Server.Clients;

internal class InvestecClient : BaseHttpClient, IInvestecClient
{
    private readonly IOptions<InvestecClientOptions> _options;

    public InvestecClient(ILogger<InvestecClient> logger, IOptions<InvestecClientOptions> options, HttpClient client) : base(logger, client)
    {
        _options = options;
    }

    public async Task<AccountResponse> GetAccountsAsync(CancellationToken token = default)
    {
        return await WrapRetryRequestAsync(async client =>
        {
            var request = client.WithHeader("Content-Type", "application/json")
                .Request();

            request.Url = new Url(_options.Value.Api)
                .AppendPathSegment("za")
                .AppendPathSegment("pb")
                .AppendPathSegment("v1")
                .AppendPathSegment("accounts")
                .AppendPathSegment("beneficiaries");

            return await request.GetJsonAsync<AccountResponse>(cancellationToken: token);
        });
    }
}
