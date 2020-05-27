using Microsoft.EntityFrameworkCore;

namespace Infestation_reports.Models
{
    public class InfestationContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Human> Humans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=POLIMISHKA; Initial Catalog=Infestation; Integrated Security=SSPI;");
        }
    }
}
