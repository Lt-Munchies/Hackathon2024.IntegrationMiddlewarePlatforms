using Newtonsoft.Json;

namespace Hackathorn2024.Server.Models
{
    public class UploadFileResponse
    {
        [JsonProperty("sourceId")]
        public string SourceID { get; set; }
    }
}
