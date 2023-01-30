using Microsoft.EntityFrameworkCore;
using PracticalTask2.Entities;

namespace PracticalTask2
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TestDatabase");
        }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Recipient> Recipients { get; set; }
    }
}
