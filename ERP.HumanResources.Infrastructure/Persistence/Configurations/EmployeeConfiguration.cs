using ERP.HumanResources.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.HumanResources.Infrastructure.Persistence.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.FullName)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(e => e.Email)
               .IsRequired()
               .HasMaxLength(200);
        builder.HasIndex(e => e.Email)
               .IsUnique();   // Prevent duplicate emails

        builder.Property(e => e.DateOfJoining)
                .IsRequired();

        builder.Property(e => e.Phone)
                .HasMaxLength(10);

        builder.Property(e => e.Department)
               .IsRequired()
               .HasMaxLength(10);

        builder.Property(e => e.Designation)    
                .IsRequired()
                .HasMaxLength(20);

        builder.Property(e => e.EmployeeCode)
                .IsRequired()
                .HasMaxLength(10);
        builder.HasIndex(e => e.EmployeeCode)
                .IsUnique();   // Prevent duplicate employee codes




    }
}