namespace ERP.HumanResources.Domain.Entities;

public class EmployeeDetails
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public string? FatherName { get; set; }

    public string? MotherName { get; set; }

    public string? Gender { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? BloodGroup { get; set; }

    public string? MaritalStatus { get; set; }

    public string? AadhaarNumber { get; set; }

    public Employee Employee { get; set; } = null!;
}