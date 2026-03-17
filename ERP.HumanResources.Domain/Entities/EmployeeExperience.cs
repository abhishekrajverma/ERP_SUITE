namespace ERP.HumanResources.Domain.Entities;

public class EmployeeExperience
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public string CompanyName { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public Employee Employee { get; set; } = null!;
}