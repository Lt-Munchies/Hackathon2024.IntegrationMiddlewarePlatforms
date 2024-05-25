using Hackathorn2024.Server.Clients;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hackathorn2024.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvestecController(IInvestecClient investecClient) : ControllerBase
    {
        [HttpGet(Name = "GetAccounts")]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await investecClient.GetAccountsAsync();
            return Ok(accounts);
        }
    }
}
