namespace ERP.HumanResources.Domain.Entities;

public class Designation
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}