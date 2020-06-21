using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfestationReports.Models
{
    public class InfestationContext : IdentityDbContext
    {
        public InfestationContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Human> Humans { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<WorldPart> WorldParts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WorldPart>().HasData(
                new WorldPart
                {
                    Id = 1,
                    Name = "Europe"
                },
                new WorldPart
                {
                    Id = 2,
                    Name = "Asia"
                },
                new WorldPart
                {
                    Id = 3,
                    Name = "Africa"
                },
                new WorldPart
                {
                    Id = 4,
                    Name = "America"
                },
                new WorldPart
                {
                    Id = 5,
                    Name = "Australia"
                },
                new WorldPart
                {
                    Id = 6,
                    Name = "Antarctica"
                });
        }
    }

}

