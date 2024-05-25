using Flurl.Http;
using Hackathorn2024.Server.Models;
using Hackathorn2024.Server.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace Hackathorn2024.Server.Clients
{
    public class PdfClient : BaseHttpClient, IPdfChatClient
    {
        private readonly IOptions<PdfChatClientOptions> _options;

        public PdfClient(ILogger<PdfClient> logger, IOptions<PdfChatClientOptions> options, HttpClient client) : base(logger, client)
        {
            _options = options;
        }

        public async Task<PromptResponse> Prompt(string prompt, string sourceID, CancellationToken token = default)
        {
            var data = new ChatRequest
            {
                sourceId = sourceID,
                messages = new[]
            {
                new Message
                {
                    role = "user",
                    content = prompt
                }
            }
            };

            var jsondata = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            return await WrapRetryRequestAsync(async client =>
            {
                var response = await client.Request(_options.Value.ChatEndpoint)
                    .WithHeader("x-api-key", _options.Value.ApiKey)
                    .PostAsync(jsondata);

                var responseBody = await response.GetStringAsync();
                return JsonConvert.DeserializeObject<PromptResponse>(responseBody);
            });
        }

        public async Task<UploadFileResponse> UploadFile(string filepath, CancellationToken token = default)
        {
            using (var fileStream = File.OpenRead("C:/testfiles/"+filepath))
            {
                var form = new MultipartFormDataContent();
                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/pdf");
                form.Add(fileContent, "file", Path.GetFileName(filepath));

                return await WrapRetryRequestAsync(async client =>
                {
                    var response = await client.Request(_options.Value.UploadEndpoint)
                        .WithHeader("x-api-key", _options.Value.ApiKey)
                        .PostAsync(form);

                    var responseBody = await response.GetStringAsync();
                    var responseJson = JObject.Parse(responseBody);

                    return new UploadFileResponse
                    {
                        SourceID = responseJson["sourceId"].ToString()
                    };
                });
            }
        }
    }

    public class Message
    {
        public string role { get; set; }
        public string content { get; set; }
    }

    public class ChatRequest
    {
        public string sourceId { get; set; }
        public Message[] messages { get; set; }
    }
}
