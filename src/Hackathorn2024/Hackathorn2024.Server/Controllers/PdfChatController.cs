using Hackathorn2024.Server.Clients;
using Hackathorn2024.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hackathorn2024.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class pdfChatController(IPdfChatClient pdfCLient) : ControllerBase
    {
        [HttpPost(Name = "UploadFile")]
        public async Task<IActionResult> UploadFile(string filepath)
        {
            var response = await pdfCLient.UploadFile(filepath);
            return Ok(response);
        }

        [HttpPost(Name = "Prompt")]
        public async Task<IActionResult> Prompt(PromptRequest request)
        {
            var response = await pdfCLient.Prompt(request.Prompt, request.sourceId);
            return Ok(response);
        }
    }
}
