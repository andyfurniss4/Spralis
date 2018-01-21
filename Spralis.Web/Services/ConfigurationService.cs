using System.Configuration;

namespace Spralis.Web.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public string Get(string key)
        {
            return ConfigurationManager.AppSettings.Get($"EST.{key}");
        }
    }
}