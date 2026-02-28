using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.HumanResources.Application.DTOs;
using ERP.HumanResources.Domain.Entities;
using Intuit.Ipp.Data;

namespace ERP.HumanResources.Application.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        Employee Create(EmployeeCreateDto dto);
        void Update(int id, EmployeeUpdateDto dto);
        void Delete(int id);
    }
}
