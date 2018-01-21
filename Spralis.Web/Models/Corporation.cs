using Newtonsoft.Json;
using System;

namespace Spralis.Web.Models
{
    public class Corporation
    {
        public int CorporationId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "ticker")]
        public string Ticker { get; set; }
        [JsonProperty(PropertyName = "member_count")]
        public int MemberCount { get; set; }
        [JsonProperty(PropertyName = "ceo_id")]
        public int CEOId { get; set; }
        [JsonProperty(PropertyName = "alliance_id")]
        public int AllianceId { get; set; }
        [JsonProperty(PropertyName = "date_founded")]
        public DateTime DateFounded { get; set; }

        public int[] MemberIds { get; set; }
    }
}