using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;

namespace OT.Assessment.App.Models
    {
    public class WagerEventModel
        {

        [JsonPropertyName("Id")]
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("wagerId")]
        public Guid WagerId { get; set; }

        [JsonPropertyName("theme")]
        public string Theme { get; set; }

        [JsonPropertyName("provider")]
        public string Provider { get; set; }

        [JsonPropertyName("gameName")]
        public string GameName { get; set; }

        [JsonPropertyName("transactionId")]
        public Guid TransactionId { get; set; }

        [JsonPropertyName("brandId")]
        public Guid BrandId { get; set; }

        [JsonPropertyName("accountId")]
        public Guid AccountId { get; set; }

        [JsonPropertyName("Username")]
        public string Username { get; set; }

        [JsonPropertyName("externalReferenceId")]
        public Guid ExternalReferenceId { get; set; }

        [JsonPropertyName("transactionTypeId")]
        public Guid TransactionTypeId { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("createdDateTime")]
        public DateTimeOffset CreatedDateTime { get; set; }

        [JsonPropertyName("numberOfBets")]
        public Int16  NumberOfBets { get; set; }

        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }

        [JsonPropertyName("sessionData")]
        public string SessionData { get; set; }

        [JsonPropertyName("Duration")]
        public long Duration { get; set; }
        }
    }
