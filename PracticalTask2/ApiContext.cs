using Microsoft.EntityFrameworkCore;
using PracticalTask2.Entities;

namespace PracticalTask2
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var config = configuration.Build();

            optionsBuilder.UseInMemoryDatabase(config.GetSection("DatabaseName").Value);
        }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Recipient> Recipients { get; set; }
    }
}
