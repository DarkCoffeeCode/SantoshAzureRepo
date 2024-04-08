using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SantoshAzure.Pages.Shared
{
    public class _WeatherViewModel : PageModel
    {
        public void OnGet()
        {
        }

        public string City { get; set; }


    }
}
