using Hackathorn2024.Server.Models;

namespace Hackathorn2024.Server.Clients;

public interface IInvestecClient
{
    Task<AccountResponse> GetAccountsAsync(CancellationToken token = default);
}
