using Spralis.Web.Models;
using Spralis.Web.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

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

            this.apiBaseURL = configurationService.Get("EST.ESI.API.BaseURL");
            this.dataSource = configurationService.Get("EST.ESI.API.DataSource");            
        }

        public Character GetCharacter(int characterID)
        {
            return JsonConvert.DeserializeObject<Character>(GetFromESI($"/characters/{characterID}/"));
        }

        private string GetFromESI(string path)
        {
            using (var httpClient = new HttpClient())
            {
                var url = $"{apiBaseURL}/{path.TrimStart('/')}?datasource={dataSource}";
                var response = httpClient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    throw new ArgumentException("Invalid path");
                }
            }
        }
    }
}