using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace server.Web.Pages
{

    public class DashboardModel(ILogger<DashboardModel> logger) : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public bool Onboarding { get; set; }
   
        public void OnGet()
        {
            logger.LogInformation("Dashboard page accessed with onboarding={Onboarding}", Onboarding);
        }
       
    }
}
