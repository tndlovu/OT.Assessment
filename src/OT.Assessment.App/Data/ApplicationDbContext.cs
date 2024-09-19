using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace OT.Assessment.App.Data
    {
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
        {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
            {
            
            }

            public DbSet<WagerEventModel> WagerEvent { get; set; }=null;
            public DbSet<Provider> Provider { get; set; } = null;
            public DbSet<Game> Games { get; set; } = null;
            public DbSet<Player> Players { get; set; } = null;
        }
        }
    
