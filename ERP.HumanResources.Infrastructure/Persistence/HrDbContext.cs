using ERP.HumanResources.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.HumanResources.Infrastructure.Persistence;

public class HrDbContext : DbContext
{
    public HrDbContext(DbContextOptions<HrDbContext> options) : base(options) { }

    public DbSet<Employee> Employees => Set<Employee>();
}