using Spralis.Web.Models;

namespace Spralis.Web.ViewModels
{
    public class SearchViewModel
    {
        public SearchViewModel()
        {
            Search = new Search();
        }

        public Search Search { get; set; }
        public string ResultJson { get; set; }
    }
}