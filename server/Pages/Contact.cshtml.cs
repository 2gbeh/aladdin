using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace server.Pages
{
    public class ContactModel : PageModel
    {
        private readonly ILogger<ContactModel> _logger;

        public ContactModel(ILogger<ContactModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public bool MessageSent { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Name")]
            public string Name { get; set; } = string.Empty;

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; } = string.Empty;

            [Required]
            [Display(Name = "Message")]
            public string Message { get; set; } = string.Empty;
        }

        public void OnGet()
        {
            _logger.LogInformation("Contact page accessed");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Simulate sending the message
            _logger.LogInformation("Contact form submitted by {Name} ({Email})", Input.Name, Input.Email);
            
            MessageSent = true;
            ModelState.Clear();
            Input = new InputModel();

            return Page();
        }
    }
}
