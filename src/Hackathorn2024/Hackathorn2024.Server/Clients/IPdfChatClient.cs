using Hackathorn2024.Server.Models;

namespace Hackathorn2024.Server.Clients
{
    public interface IPdfChatClient
    {
        Task<UploadFileResponse> UploadFile(string filepath, CancellationToken token = default);

        Task<PromptResponse> Prompt(string prompt, string sourceID, CancellationToken token = default);
    }
}
