﻿using Spralis.Web.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace Spralis.Web.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IConfigurationService configurationService;

        private string clientId;
        private string secretKey;

        public AuthorizationService(IConfigurationService configurationService)
        {
            this.configurationService = configurationService;

            this.clientId = configurationService.Get("ESI.Auth.ClientId");
            this.secretKey = configurationService.Get("ESI.Auth.Secretkey");
        }

        public string GetAuthorizeURL()
        {
            var stateGuid = Guid.NewGuid();
            return $"{configurationService.Get("ESI.Auth.AuthorizeURL")}?response_type=code&redirect_uri={configurationService.Get("ESI.Auth.CallbackURL")}&client_id={clientId}&scope=characterKillsRead&state={stateGuid.ToString()}";
        }

        public GetAccessTokenResponse GetAccessToken(string code)
        {
            using (var httpClient = new HttpClient())
            {
                var authorizationToken = Utility.Encoder.Base64Encode($"{clientId}:{secretKey}");

                var request = new HttpRequestMessage(HttpMethod.Post, configurationService.Get("ESI.Auth.TokenURL"));
                request.Headers.Add("Authorization", $"Basic {authorizationToken}");
                request.Headers.Add("Host", "login.eveonline.com");
                request.Content = new StringContent($"grant_type=authorization_code&code={code}", Encoding.UTF8, "application/x-www-form-urlencoded");

                var responseMessage = httpClient.SendAsync(request).Result;

                return JsonConvert.DeserializeObject<GetAccessTokenResponse>(responseMessage.Content.ReadAsStringAsync().Result);
            }            
        }
    }
}