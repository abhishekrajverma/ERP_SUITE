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
    //[Authorize(Roles = "Admin")]
    public IActionResult Create(EmployeeCreateDto dto)
    {
        return Ok(_service.Create(dto));
    }
}