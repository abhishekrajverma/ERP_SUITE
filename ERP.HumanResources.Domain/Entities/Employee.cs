namespace ERP.HumanResources.Domain.Entities;

public class Employee
{
    public int Id { get; set; }

    public required string EmployeeCode { get; set; }

    public required string FullName { get; set; }

    public required string Email { get; set; }

    public required string Phone { get; set; }

    public DateTime DateOfJoining { get; set; }

    public int DepartmentId { get; set; }

    public int DesignationId { get; set; }

    public int? ShiftId { get; set; }

    public Department Department { get; set; } = null!;

    public Designation Designation { get; set; } = null!;

    public Shift? Shift { get; set; }

    public EmployeeDetails? EmployeeDetails { get; set; }

    public EmployeeAddress? Address { get; set; }

    public ICollection<EmployeeDocument> Documents { get; set; } = new List<EmployeeDocument>();

    public ICollection<EmployeeExperience> Experiences { get; set; } = new List<EmployeeExperience>();

    public ICollection<EmployeeQualification> Qualifications { get; set; } = new List<EmployeeQualification>();
}