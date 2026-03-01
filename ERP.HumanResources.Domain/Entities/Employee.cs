namespace ERP.HumanResources.Domain.Entities;

public class Employee
{
    public int Id { get; set; }
    public required string EmployeeCode { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string Department { get; set; }
    public required string Designation { get; set; }
}