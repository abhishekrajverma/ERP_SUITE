using ERP.HumanResources.Domain.Entities;

namespace ERP.HumanResources.Application.Interfaces;

public interface IEmployeeRepository
{
    IEnumerable<Employee> GetAll();
    Employee? GetById(int id);
    Employee Add(Employee employee);
    void Update(Employee employee);
    void Delete(Employee employee);
}