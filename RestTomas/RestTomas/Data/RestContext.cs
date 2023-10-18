using RestTomas.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace RestTomas.Data
{
    public class RestContext : DbContext
    {
        public DbSet<Center> Centers { get; set; }
        public DbSet<Technician> Technicians { get; set; }

        public DbSet<Job> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=(localdb)\\MSSQLLocalDB; Initial Catalog=RestDemo2");
        }
    }
}
