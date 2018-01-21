using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spralis.Web.Models
{
    public class SearchResult
    {
        [JsonProperty(PropertyName = "character")]
        public IList<int> CharacterIds { get; set; }
        [JsonProperty(PropertyName = "corporation")]
        public IList<int> CorporationIds { get; set; }
        [JsonProperty(PropertyName = "alliance")]
        public IList<int> AllianceIds { get; set; }

        public IList<Character> Characters { get; set; }
        public IList<Character> Corporations { get; set; }
        public IList<Character> Alliances { get; set; }
    }
}