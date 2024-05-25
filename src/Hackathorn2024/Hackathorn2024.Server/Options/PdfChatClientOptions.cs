namespace Hackathorn2024.Server.Options
{
    public class PdfChatClientOptions
    {
        public string ApiKey { get; set; } = "sec_g9XpJmOpRR6geM2PHe4zSNBbCDGEYEUM";
        public string UploadEndpoint { get; set; } = "https://api.chatpdf.com/v1/sources/add-file";
        public string ChatEndpoint { get; set; } = "https://api.chatpdf.com/v1/chats/message";
    }
}
