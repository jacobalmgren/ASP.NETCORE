using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication5.Models; // Make sure this uses your actual namespace

namespace WebApplication5.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty] // This will bind form data to the property
        public NewsletterSignupModel NewsletterSignupModel { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // Method when page is accessed via GET
        }

        public IActionResult OnPostSubscribe()
        {
            if (!ModelState.IsValid)
            {
                // Handle the case where the model is not valid
                return Page(); // Return back to the page to show validation errors
            }

            // Logic to handle the subscription like storing email in database
            // For now, let's just log the email for simplicity
            _logger.LogInformation("New Newsletter Subscription: {Email}", NewsletterSignupModel.Email);

            // Here, you could redirect the user to a 'Thank You' page or back to the index with a success message
            return RedirectToPage(); // Simple redirect back to the Index page
        }
    }
}
