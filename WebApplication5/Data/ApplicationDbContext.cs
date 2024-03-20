using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace WebApplication5.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> // Change made here
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet declarations for your entities
    }
}
