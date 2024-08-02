using Microsoft.EntityFrameworkCore;
using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace api.Data
{
    public class apiContext : IdentityDbContext<AppUser>
    {
        public apiContext (DbContextOptions<apiContext> options)
            : base(options)
        {
        }

        public DbSet<api.Models.WeatherLocation> WeatherLocation { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>();
            roles.Add(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
            roles.Add(new IdentityRole { Name = "User", NormalizedName = "USER" });
        }
    }
}
