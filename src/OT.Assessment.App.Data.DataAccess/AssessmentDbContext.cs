using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OT.Assessment.App.Models;

namespace OT.Assessment.Data.DataAccess
    {
    public class AssessmentDbContext : DbContext
        {
        public AssessmentDbContext(DbContextOptions<AssessmentDbContext> options)
            : base(options)
            { }
            public DbSet<WagerEventModel> WagerEvent { get; set; } = null;
            public DbSet<Provider> Provider { get; set; } = null;
            public DbSet<Game> Game { get; set; } = null;
            public DbSet<Player> Player { get; set; } = null;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test;ConnectRetryCount=0");
            }
        }
    }
    
        
