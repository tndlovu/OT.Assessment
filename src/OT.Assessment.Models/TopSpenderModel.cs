using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OT.Assessment.App.Models
    {
    public class TopSpenderModel
        {
        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        [JsonPropertyName("Username")]
        public string Username { get; set; }

        [JsonPropertyName("totalAmountSpend")]
        public string TotalAmountSpend { get; set; }
        }
    }
