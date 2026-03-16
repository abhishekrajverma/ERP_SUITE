using ERP.HumanResources.Application.Interfaces;
using ERP.HumanResources.Domain.Entities;
using ERP.HumanResources.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ERP.HumanResources.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository  // ← changed
{
    private readonly HrDbContext _context;

    public EmployeeRepository(HrDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Employee> GetAll()
        => _context.Employees.ToList();

    public Employee? GetById(int id)
        => _context.Employees.Find(id);

    public Employee Add(Employee employee)
    {
        try
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }
        catch (DbUpdateException ex)
        {
            var message = ex.InnerException?.Message ?? "";

            if (message.Contains("IX_Employees_Email"))
                throw new Exception("Email already exists.");

            if (message.Contains("IX_Employees_Phone"))
                throw new Exception("Phone number already exists.");

            throw; // rethrow if it’s some other DB problem
        }
    }

    public void Update(Employee employee)
    {
        _context.Employees.Update(employee);
        _context.SaveChanges();
    }

    public void Delete(Employee employee)
    {
        _context.Employees.Remove(employee);
        _context.SaveChanges();
    }
}