using ERP.HumanResources.Application.DTOs;
using ERP.HumanResources.Application.Interfaces;
using ERP.HumanResources.Domain.Entities;
using Intuit.Ipp.Data;

namespace ERP.HumanResources.Application.Services;

public class EmployeeService : IEmployeeService
{
    private static readonly List<Employee> _employees = new();
    private static int _id = 1;

    public IEnumerable<Employee> GetAll() => _employees;

    public Employee GetById(int id) =>
        _employees.FirstOrDefault(e => e.Id == id);

    public Employee Create(EmployeeCreateDto dto)
    {
        var employee = new Employee
        {
            Id = _id++,
            EmployeeCode = dto.EmployeeCode,
            FullName = dto.FullName,
            Email = dto.Email,
            Department = dto.Department,
            Designation = dto.Designation,
            DateOfJoining = dto.DateOfJoining,
            IsActive = true
        };

        _employees.Add(employee);
        return employee;
    }

    public void Update(int id, EmployeeUpdateDto dto)
    {
        var emp = GetById(id);
        if (emp == null) return;

        emp.FullName = dto.FullName;
        emp.Department = dto.Department;
        emp.Designation = dto.Designation;
        emp.IsActive = dto.IsActive;
    }

    public void Delete(int id)
    {
        var emp = GetById(id);
        if (emp != null) _employees.Remove(emp);
    }
}