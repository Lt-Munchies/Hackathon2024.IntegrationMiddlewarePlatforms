using Newtonsoft.Json;

namespace Hackathorn2024.Server.Models;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class AccountResponse
{
    [JsonProperty("data")]
    public Data Data { get; set; }

    [JsonProperty("links")]
    public Links Links { get; set; }

    [JsonProperty("meta")]
    public Meta Meta { get; set; }
}

public class Data
{
    [JsonProperty("accounts")]
    public List<Account> Accounts { get; set; }
}

public class Account
{
    [JsonProperty("accountId")]
    public string AccountId { get; set; }

    [JsonProperty("accountNumber")]
    public string AccountNumber { get; set; }

    [JsonProperty("accountName")]
    public string AccountName { get; set; }

    [JsonProperty("referenceName")]
    public string ReferenceName { get; set; }

    [JsonProperty("productName")]
    public string ProductName { get; set; }
}

public class Links
{
    [JsonProperty("self")]
    public Uri Self { get; set; }
}

public class Meta
{
    [JsonProperty("totalPages")]
    public long TotalPages { get; set; }
}
