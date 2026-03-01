namespace ERP.HumanResources.Api.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? EmployeeCode { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Department { get; set; }
        public string? Designation { get; set; }
        public DateTime DateOfJoining { get; set; }
        public bool IsActive { get; set; }
    }
}
