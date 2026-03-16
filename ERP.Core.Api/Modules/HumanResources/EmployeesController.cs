using ERP.HumanResources.Application.DTOs;
using ERP.HumanResources.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Core.Api.Controllers.modules.HumanResources;


[ApiController]
[Route("api/employees")]
//[Authorize(Roles = "Admin,HR")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _service;

    public EmployeesController(IEmployeeService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetAll());
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult Create(EmployeeCreateDto dto)
    {
        try
        {
            var result = _service.Create(dto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                message = ex.Message
            });
        }
    }
}
