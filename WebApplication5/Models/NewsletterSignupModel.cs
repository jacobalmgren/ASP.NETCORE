namespace WebApplication5.Models
{
    public class NewsletterSignupModel
    {
        public string Email { get; set; }
        public bool DailyNewsletter { get; set; }
        public bool AdvertisingUpdates { get; set; }
        public bool WeekInReview { get; set; }
        public bool EventUpdates { get; set; }
        public bool StartupWeekly { get; set; }
        public bool Podcasts { get; set; }
    }
}
