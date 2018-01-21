using Newtonsoft.Json;

namespace Spralis.Web.Models
{
    public class Character
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "corporation_id")]
        public int CorporationID { get; set; }

        [JsonProperty(PropertyName = "alliance_id")]
        public int AllianceID { get; set; }

        [JsonProperty(PropertyName = "birthday")]
        public int DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "security_status")]
        public decimal SecurityStatus { get; set; }

        [JsonProperty(PropertyName = "faction_id")]
        public decimal FactionID { get; set; }
    }
}