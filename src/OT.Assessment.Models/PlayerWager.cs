using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OT.Assessment.App.Models
    {
    public class PlayerWager
        {
        [JsonPropertyName("wagerId")]
        public string WagerId { get; set; }
        [JsonPropertyName("game")]
        public string GameName { get; set; }
        [JsonPropertyName("provider")]
        public string Provider { get; set; }
        [JsonPropertyName("amount")]
        public string Amount { get; set; }
        [JsonPropertyName("createdDate")]
        public string CreatedDate { get; set; }
        }
    }
