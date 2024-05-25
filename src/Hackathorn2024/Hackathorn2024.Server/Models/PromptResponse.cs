using Newtonsoft.Json;

namespace Hackathorn2024.Server.Models
{
    public class PromptResponse
    {
        [JsonProperty("Business Name")]
        public string BusinessName { get; set; }
        [JsonProperty("Bank Name")]
        public string BankName { get; set; }
        [JsonProperty("Branch Name")]
        public string BranchName { get; set; }
        [JsonProperty("Branch Number")]
        public string BranchNumber { get; set; }
        [JsonProperty("Account Number")]
        public string AccountNumber { get; set; }
        [JsonProperty("Account Name")]
        public string AccountName { get; set; }
        [JsonProperty("Payment Reference")]
        public string PaymentReference { get; set; }
        [JsonProperty("Invoice Total")]
        public string InvoiceTotal { get; set; }
    }

    public class Content
    {
        [JsonProperty("content")]
        public PromptResponse response { get; set; }
    }
}
