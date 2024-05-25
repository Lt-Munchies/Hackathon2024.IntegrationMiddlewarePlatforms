using Newtonsoft.Json;

namespace Hackathorn2024.Server.Models
{
    public class PromptResponse
    {
        [JsonProperty("BusinessName")]
        public string BusinessName { get; set; }

        [JsonProperty("BankName")]
        public string BankName { get; set; }

        [JsonProperty("BranchName")]
        public string BranchName { get; set; }

        [JsonProperty("BranchNumber")]
        public long BranchNumber { get; set; }

        [JsonProperty("AccountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("AccountName")]
        public string AccountName { get; set; }

        [JsonProperty("PaymentReference")]
        public long PaymentReference { get; set; }

        [JsonProperty("InvoiceTotal")]
        public string InvoiceTotal { get; set; }
    }

    public class Root
    {
        public PromptResponse Content { get; set; }
    }

}
