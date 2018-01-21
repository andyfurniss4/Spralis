using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Spralis.Web.Models
{
    public class Search
    {
        public Search()
        {
            DataSources = new List<string>()
            {
                "Tranquility",
                "Singularity"
            };
            SelectedDataSource = "Tranquility";
            Categories = new List<SearchCategory>()
            {
                new SearchCategory()
                {
                    Category = "Character",
                    Selected = true
                },
                new SearchCategory()
                {
                    Category = "Corporation",
                    Selected = true
                },
                new SearchCategory()
                {
                    Category = "Alliance",
                    Selected = true
                }
            };
            Language = "en-us";
            Strict = true;
        }

        [Required]
        [Display(Name = "Search")]
        public string SearchString { get; set; }
        public IList<string> DataSources { get; set; }
        [Display(Name = "Server")]
        public string SelectedDataSource { get; set; }
        public IList<SearchCategory> Categories { get; set; }
        public string Language { get; set; }
        public bool Strict { get; set; }
    }

    public class SearchCategory
    {
        public string Category { get; set; }
        public bool Selected { get; set; }
    }
}