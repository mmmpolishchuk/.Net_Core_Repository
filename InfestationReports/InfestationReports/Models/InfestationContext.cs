using Microsoft.EntityFrameworkCore;

namespace InfestationReports.Models
{
    public class InfestationContext : DbContext
    {
        public InfestationContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Human> Humans { get; set; }
       
    }
}
