using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.HumanResources.Application.DTOs
{
    public class EmployeeUpdateDto
    {
        public string FullName { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
