using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.HumanResources.Application.DTOs
{
    public class EmployeeCreateDto
    {
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; } = string.Empty;
        public string Designation { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}
