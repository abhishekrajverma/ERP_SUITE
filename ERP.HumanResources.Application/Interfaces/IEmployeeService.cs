using ERP.HumanResources.Application.DTOs;

namespace ERP.HumanResources.Application.Interfaces;

public interface IEmployeeService
{
    IEnumerable<EmployeeCreateDto> GetAll();
    EmployeeCreateDto Create(EmployeeCreateDto dto);
}