using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.HumanResources.Api.Controllers;

//[Authorize] // 🔐 THIS IS THE CONNECTION
[ApiController]
[Route("api/employees")]
public class EmployeesController : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = "Admin,HR")]
    public IActionResult GetEmployees()
    {
        return Ok(new[]
        {
            new { Id = 1, Name = "Rahul", Department = "IT" },
            new { Id = 2, Name = "Anita", Department = "HR" }
        });
    }
}