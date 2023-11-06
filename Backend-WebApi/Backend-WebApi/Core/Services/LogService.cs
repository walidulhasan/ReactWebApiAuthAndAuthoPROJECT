using Backend_WebApi.Core.DbContext;
using Backend_WebApi.Core.Dtos.Log;
using Backend_WebApi.Core.Entities;
using Backend_WebApi.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Backend_WebApi.Core.Services;

public class LogService : ILogService
{
    private readonly ApplicationDbContext _context;

    public  LogService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task SaveNewlog(string UserName, string Description)
    {
        var newLog = new Log()
        {
            UserName = UserName,
            Description = Description
        };
        await _context.AddAsync(newLog);
        await _context.SaveChangesAsync();
    }
    public async Task<IEnumerable<GetLogDto>> GetLoggsAsync()
    {
        var logs = await _context.Logs
            .Select(x => new GetLogDto
            {
                CreatedAt =x.CreatedAt,
                Description = x.Description,
                UserName = x.UserName
            })
            .OrderByDescending(x=>x.CreatedAt)
            .ToListAsync();
        return logs;
    }

    public async Task<IEnumerable<GetLogDto>> GetMyLogsAsync(ClaimsPrincipal User)
    {
        var logs = await _context.Logs
            .Where(x=>x.UserName== User.Identity.Name)
            .Select(x => new GetLogDto
            {
                CreatedAt = x.CreatedAt,
                Description = x.Description,
                UserName = x.UserName
            })
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
        return logs;
    }

    
}
