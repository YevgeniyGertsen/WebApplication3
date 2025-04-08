using Microsoft.EntityFrameworkCore;

namespace HotelAtr.WebAdmin.Models
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options){ }

        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamLynkType> TeamLynkTypes { get; set; }
        public DbSet<LynkType> LynkTypes { get; set; }
    }
}
