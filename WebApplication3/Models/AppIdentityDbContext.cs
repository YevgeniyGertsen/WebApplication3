using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Language> Language { get; set; }
        public DbSet<StringResources> StringResources { get; set; }
    }
}
