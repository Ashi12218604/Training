using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureTaskAPI.DTOs;
using SecureTaskAPI.Services;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TaskController : ControllerBase
{
    private readonly ITaskService _service;

    public TaskController(ITaskService service)
    {
        _service = service;
    }

    [AllowAnonymous]   
    [HttpPost("user")]
    public IActionResult CreateUser(CreateUserDTO dto)
    {
        return Ok(_service.CreateUser(dto));
    }

    [HttpPost("task")]
    public IActionResult CreateTask(CreateTaskDTO dto)
    {
        return Ok(_service.CreateTask(dto));
    }
}