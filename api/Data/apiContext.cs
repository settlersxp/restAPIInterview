using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace api.Data
{
    public class apiContext : IdentityDbContext<AppUser>
    {
        public apiContext (DbContextOptions<apiContext> options)
            : base(options)
        {
        }

        public DbSet<api.Models.WeatherLocation> WeatherLocation { get; set; } = default!;
    }
}
