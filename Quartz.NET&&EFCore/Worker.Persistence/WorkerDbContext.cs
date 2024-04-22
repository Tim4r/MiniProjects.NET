using Microsoft.EntityFrameworkCore;
using Worker.Contracts.Entities;

namespace Worker.Persistence;

public class WorkerDbContext : DbContext
{
    public WorkerDbContext(DbContextOptions<WorkerDbContext> dbContextOptions) : base(dbContextOptions)
    {
        
    }

    public DbSet<Log> Logs { get; set; }
}