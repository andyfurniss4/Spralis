using Spralis.Web.Services;
using Spralis.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Spralis.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IAPIService esiService;

        public SearchController(IAPIService esiService)
        {
            this.esiService = esiService;
        }

        // GET: Search
        public ActionResult Index()
        {
            return View(new SearchViewModel());
        }

        // POST: Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(SearchViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (!viewModel.Search.Categories.Any(x => x.Selected))
                {
                    ModelState.AddModelError("Search.Categories", "Please select at least one category");
                    return View(viewModel);
                }

                viewModel.ResultJson = await esiService.Search(viewModel.Search);
            }

            return View(viewModel);
        }
    }
}