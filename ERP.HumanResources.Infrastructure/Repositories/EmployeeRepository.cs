using ERP.HumanResources.Application.Interfaces;
using ERP.HumanResources.Domain.Entities;
using ERP.HumanResources.Infrastructure.Persistence;

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
        _context.Employees.Add(employee);
        _context.SaveChanges();
        return employee;
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