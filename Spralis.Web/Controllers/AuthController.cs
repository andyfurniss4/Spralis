using Spralis.Services;
using System.Web.Mvc;

namespace Spralis.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthorizationService authService;

        public AuthController(IAuthorizationService authService)
        {
            this.authService = authService;
        }

        // GET: Auth
        public void Index()
        {
            Response.Redirect(authService.GetAuthorizeURL());
        }

        // GET: Auth/Complete
        public ActionResult Complete()
        {
            var code = Request.QueryString.Get("code");
            var state = Request.QueryString.Get("state");

            if (!string.IsNullOrWhiteSpace(code))
            {
                var tokenResponse = authService.GetAccessToken(code);

                return View("Complete", (object)tokenResponse.AccessToken);
            }

            return View();
        }

        // GET: Auth/GetCharacterDetails
    }
}