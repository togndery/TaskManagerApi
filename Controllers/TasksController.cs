using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TasksController(ITaskService taskService, IHttpContextAccessor accessor)
    {
        _taskService = taskService;
        _httpContextAccessor = accessor;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var tasks = await _taskService.GetAllAsync(userId);
        return Ok(tasks);
    }
}