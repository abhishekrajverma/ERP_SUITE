namespace ERP.HumanResources.Domain.Entities;

public class Shift
{
    public int Id { get; set; }

    public string ShiftName { get; set; } = string.Empty;

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}