using Microsoft.EntityFrameworkCore;
namespace DotnetBakery.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

        // reference the classes and tables we need
        public DbSet<Baker> Bakers {get; set;} // referring to the baker class and setting it as a column in the DB
        public DbSet<Bread> Breads {get; set;}
    }
}