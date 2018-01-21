using Spralis.Web.Models;

namespace Spralis.Web.Services
{
    public interface IAuthorizationService
    {
        string GetAuthorizeURL();
        GetAccessTokenResponse GetAccessToken(string code);
    }
}