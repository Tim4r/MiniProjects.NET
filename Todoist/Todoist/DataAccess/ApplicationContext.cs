using Microsoft.EntityFrameworkCore;
using Todoist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todoist.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Goal> Goals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.DESKTOP-FQLO9UO\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
        }
    }
}
