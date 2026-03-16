using Microsoft.EntityFrameworkCore;
using ERP.HumanResources.Domain.Entities;

namespace ERP.HumanResources.Infrastructure.Persistence;

public class HrDbContext : DbContext
{
    public HrDbContext(DbContextOptions<HrDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}