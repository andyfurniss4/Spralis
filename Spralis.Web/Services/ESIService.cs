using Spralis.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;

namespace Spralis.Web.Services
{
    public class ESIService : IAPIService
    {
        private readonly IConfigurationService configurationService;

        private readonly string apiBaseURL;
        private readonly string dataSource;

        public ESIService(IConfigurationService configurationService)
        {
            this.configurationService = configurationService;

            this.apiBaseURL = configurationService.Get("ESI.API.BaseURL");
            this.dataSource = configurationService.Get("ESI.API.DataSource");            
        }

        public async Task<string> Search(Search search)
        {
            var query = $"search={search.SearchString}&categories={String.Join(",", search.Categories.Where(x => x.Selected).Select(x => x.Category.ToLower()))}&language={search.Language}&datasource={search.SelectedDataSource.ToLower()}";
            var result = JsonConvert.DeserializeObject<SearchResult>((await GetFromESIAsync("/search/", query)));

            foreach (var characterId in result.CharacterIds)
            {
                var character = await GetCharacterAsync(characterId);
                character.CharacterId = characterId;
                result.Characters.Add(character);
            }

            return JsonConvert.SerializeObject(result);
        }

        public async Task<Character> GetCharacterAsync(int characterId)
        {
            var result = await GetFromESIAsync($"/characters/{characterId}/");
            return JsonConvert.DeserializeObject<Character>(result);
        }

        public async Task<Corporation> GetCorporationAsync(int corporationId, bool getMembers = false)
        {
            var result = await GetFromESIAsync($"/corporations/{corporationId}/");
            var corporation = JsonConvert.DeserializeObject<Corporation>(result);
            if (getMembers)
            {
                var membersResult = await GetFromESIAsync($"/corporations/{corporationId}/members/", authRequired: true);
                corporation.MemberIds = JsonConvert.DeserializeObject<int[]>(membersResult);
            }

            return corporation;
        }

        private async Task<string> GetFromESIAsync(string path, bool authRequired = false)
        {
            return await GetFromESIAsync(path, null, authRequired);
        }

        private async Task<string> GetFromESIAsync(string path, string query, bool authRequired = false)
        {
            using (var httpClient = new HttpClient())
            {
                var url = $"{apiBaseURL.TrimEnd('/')}/{path.TrimStart('/')}{(!string.IsNullOrWhiteSpace(query) ? $"?{query.TrimStart('?')}" : string.Empty)}";
                var request = new HttpRequestMessage(HttpMethod.Get, url);

                if (authRequired)
                {
                    request.Headers.Add("User-Agent", "Spralis");
                    request.Headers.Add("Authorization", $"Bearer V2pPq4R4XsPR7qZ6uKt69M8Hip3iPwSCBywWsPVT9cEmN5YDAHirV4xEIdlRycVISQsCeUXZMHBBNf3kZ6Ll-Q2");
                }

                var response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}