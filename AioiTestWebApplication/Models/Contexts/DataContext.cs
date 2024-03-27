using Microsoft.EntityFrameworkCore;

namespace AioiTestWebApplication.Models.Contexts
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase("AioiTestDb");
        }

        public DbSet<Customer> Customers { get; set; }

    }
}
