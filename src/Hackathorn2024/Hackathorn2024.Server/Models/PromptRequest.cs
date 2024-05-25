namespace Hackathorn2024.Server.Models
{
    public class PromptRequest
    {
        public string Prompt { get; set; } = "Please give me the relevant details from the PDF in the following payload format.  Only if the information is available.  Please add payment reference as well.  Please return the total amount in decimal.  The payload should looks as follows: {\"Business Name\" : \"\",\"Bank Details\" : {\"Bank Name\" : \"\",\"Branch Name\" : \"\",\"Branch Number\" : \"\",\"Account Number\" : \"\",\"Account Name\" : \"\",\"Payment Reference\" : \"\"},\"Invoice Total\":\"\"}";
        public string sourceId { get; set; }
    }
}
