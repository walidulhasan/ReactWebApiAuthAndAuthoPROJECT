using Backend_WebApi.Core.Constants;
using Backend_WebApi.Core.Dtos.Log;
using Backend_WebApi.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LogsController : ControllerBase
{
    private readonly ILogService _logService;

    public LogsController(ILogService logService)
    {
        _logService = logService;
    }
    [HttpGet]
    [Authorize(Roles = StaticUserRoles.OwnerAdmin)]
    public async Task<ActionResult<IEnumerable<GetLogDto>>> GetLogs()
    {
        var logs =await _logService.GetLoggsAsync();
        return Ok(logs);
    }

    [HttpGet]
    [Route("mine")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<GetLogDto>>> GetMyLogs()
    {
        var logs = await _logService.GetMyLogsAsync(User);
        return Ok(logs);
    }
}
