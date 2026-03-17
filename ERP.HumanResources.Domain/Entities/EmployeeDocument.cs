namespace ERP.HumanResources.Domain.Entities;

public class EmployeeDocument
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public string DocumentName { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;

    public DateTime UploadedDate { get; set; } = DateTime.UtcNow;

    public Employee Employee { get; set; } = null!;
}