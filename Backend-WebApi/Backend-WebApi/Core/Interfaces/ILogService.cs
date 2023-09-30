using Backend_WebApi.Core.Dtos.Log;
using System.Security.Claims;

namespace Backend_WebApi.Core.Interfaces;

public interface ILogService
{
    Task SaveNewlog(string UserName, string Description);
    Task<IEnumerable<GetLogDto>> GetLoggsAsync();
    Task<IEnumerable<GetLogDto>> GetMyLogsAsync(ClaimsPrincipal User);
}
