using Spralis.Web.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Spralis.Web.Controllers
{
    public class CorporationController : Controller
    {
        private readonly IAPIService esiService;

        public CorporationController(IAPIService esiService)
        {
            this.esiService = esiService;
        }

        // GET: Corporation/123
        public async Task<ActionResult> Index(int corporationId)
        {
            var corporation = await esiService.GetCorporationAsync(corporationId, getMembers: true);
            return View();
        }
    }
}