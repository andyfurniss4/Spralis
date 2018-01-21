using Newtonsoft.Json;
using System;

namespace Spralis.Web.Models
{
    public class Character
    {
        public int CharacterId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "corporation_id")]
        public int CorporationId { get; set; }

        [JsonProperty(PropertyName = "alliance_id")]
        public int AllianceId { get; set; }

        [JsonProperty(PropertyName = "birthday")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "security_status")]
        public decimal SecurityStatus { get; set; }

        [JsonProperty(PropertyName = "faction_id")]
        public decimal FactionId { get; set; }
    }
}