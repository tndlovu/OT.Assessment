using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
namespace OT.Assessment.App.Models
    {
    public class PlayerGameModel
        {
        [JsonPropertyName("wagerId")]
        public IList<PlayerWager> Wagers { get; set; }
        [JsonPropertyName("page")]
        public int Page { get; set; }
        [JsonPropertyName("total")]
        public decimal Total { get; set; }
        [JsonPropertyName("totalPages")]
        public int TotalPages { get; set; }
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        }
    }
