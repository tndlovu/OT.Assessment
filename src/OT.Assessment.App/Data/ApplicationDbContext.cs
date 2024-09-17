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
        }
        }
    
