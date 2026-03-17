namespace ERP.HumanResources.Domain.Entities;

public class EmployeeQualification
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public string Degree { get; set; } = string.Empty;

    public string Institute { get; set; } = string.Empty;

    public int YearCompleted { get; set; }

    public Employee Employee { get; set; } = null!;
}