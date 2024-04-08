using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication5.Models;
using System.Diagnostics;

namespace WebApplication5.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public NewsletterSignupModel NewsletterSignupModel { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostSubscribe()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _logger.LogInformation("New Newsletter Subscription: Email={Email}, DailyNewsletter={DailyNewsletter}, AdvertisingUpdates={AdvertisingUpdates}, WeekInReview={WeekInReview}, EventUpdates={EventUpdates}, StartupWeekly={StartupWeekly}, Podcasts={Podcasts}",
                NewsletterSignupModel.Email,
                NewsletterSignupModel.DailyNewsletter,
                NewsletterSignupModel.AdvertisingUpdates,
                NewsletterSignupModel.WeekInReview,
                NewsletterSignupModel.EventUpdates,
                NewsletterSignupModel.StartupWeekly,
                NewsletterSignupModel.Podcasts);


            return RedirectToPage(); 
        }
    }
}
