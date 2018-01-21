using Newtonsoft.Json;
using Spralis.Services.Interfaces;
using Spralis.ViewModels;
using System.Web.Mvc;

namespace Spralis.Web.Controllers
{
    public class ESIController : Controller
    {
        private readonly IAPIService esiService;

        public ESIController(IAPIService esiService)
        {
            this.esiService = esiService;
        }

        // GET: ESI
        public ActionResult Index()
        {
            return View();
        }

        // POST: ESI
        [HttpPost]
        public ActionResult Index(ESIGetViewModel viewModel)
        {
            var character = esiService.GetCharacter(viewModel.CharacterID);
            viewModel.ResultJSON = JsonConvert.SerializeObject(character);
            return View(viewModel);
        }
    }
}