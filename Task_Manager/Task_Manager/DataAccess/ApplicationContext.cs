using Microsoft.EntityFrameworkCore;
using Task_Manager.Entities;

namespace Task_Manager.Connection
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Category> Categories => Set<Category>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-FQLO9UO\\SQLEXPRESS");
        }
    }
}
