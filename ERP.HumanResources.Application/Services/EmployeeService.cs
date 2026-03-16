using ERP.HumanResources.Application.DTOs;
using ERP.HumanResources.Application.Interfaces;
using ERP.HumanResources.Domain.Entities;

namespace ERP.HumanResources.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repo;

    public EmployeeService(IEmployeeRepository repo)
    {
        _repo = repo;
    }

    public IEnumerable<EmployeeCreateDto> GetAll()
        => _repo.GetAll().Select(e => new EmployeeCreateDto
        {
            Id = e.Id,
            EmployeeCode = e.EmployeeCode,
            FullName = e.FullName,
            Email = e.Email,
            Department = e.Department,
            Designation = e.Designation,
            Phone = e.Phone,
            DateOfJoining = e.DateOfJoining

        });


    // 
    public EmployeeCreateDto Create(EmployeeCreateDto dto)
    {
        var employee = new Employee
        {
            EmployeeCode = dto.EmployeeCode,
            FullName = dto.FullName,
            Email = dto.Email,
            Department = dto.Department,
            Designation = dto.Designation,
            Phone = dto.Phone,
            DateOfJoining = dto.DateOfJoining
        };
        

        var created = _repo.Add(employee);

        return new EmployeeCreateDto
        {
            Id = created.Id,
            EmployeeCode = created.EmployeeCode,
            FullName = created.FullName,
            Email = created.Email,
            Department = created.Department,
            Designation = created.Designation,
            Phone = created.Phone,
            DateOfJoining = created.DateOfJoining
        };
    }
}