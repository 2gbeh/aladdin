using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace server.Web.Pages
{
    public class LoginSchema
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
        
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; } = "";

        public string Debug()
        {
            return $"LoginSchema: Email: {Email}, Password: {Password}";
        }
    }

    public class LoginModel(ILogger<LoginModel> logger) : PageModel
    {
        [BindProperty]
        public LoginSchema FormData { get; set; } = new LoginSchema();

        public void OnGet()
        {
            logger.LogInformation("Login page accessed");
            if (Prototyping.Auth.FormData)
            {
                FormData.Email = "dehphantom@yahoo.com";
                FormData.Password = "$Strongp@ssw0rd";
            }
        }
        public IActionResult OnPost()
        {
            logger.LogInformation("{FormData}", FormData.Debug());
            
            if (!Prototyping.Auth.FormData && !ModelState.IsValid)
            {
                logger.LogWarning("Invalid login attempt with validation errors");
                return Page();
            } else
            {
                FormData = new LoginSchema();
                return RedirectToPage("/Dashboard/Index", new { onboarding = false });
            }
            
        }
    }
}
