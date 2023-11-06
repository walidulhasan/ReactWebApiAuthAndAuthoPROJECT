using Backend_WebApi.Core.DbContext;
using Backend_WebApi.Core.Dtos.General;
using Backend_WebApi.Core.Dtos.Message;
using Backend_WebApi.Core.Entities;
using Backend_WebApi.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Backend_WebApi.Core.Services;

public class MessageService : IMessageService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogService _loggerServie;
    private readonly UserManager<ApplicationUser> _userManager;
    public MessageService(ApplicationDbContext context, ILogService loggerServie, UserManager<ApplicationUser> userManager = null)
    {
        _context = context;
        _loggerServie = loggerServie;
        _userManager = userManager;
    }

    public async Task<GeneralServiceResponseDto> CreateNewMessageAsync(ClaimsPrincipal User, CreateMessageDto createMessageDto)
    {
        if (User.Identity.Name == createMessageDto.ReceiverUserName)
        {
            return new GeneralServiceResponseDto()
            {
                IsSucced = false,
                StatusCode = 400,
                Message = "Sender and Reciver can not be same"
            };
        }
        var isReceiverUserNameValid = _userManager.Users.Any(x => x.UserName == createMessageDto.ReceiverUserName);
        if (!isReceiverUserNameValid)
        {
            return new GeneralServiceResponseDto()
            {
                IsSucced = false,
                StatusCode = 400,
                Message = "receive UserName is not valid!"
            };
        }

        Message newMessage = new()
        {
            SenderUserName = User.Identity.Name,
            ReceiverUserName = createMessageDto.ReceiverUserName,
            Text = createMessageDto.Text
        };
        await _context.Messages.AddAsync(newMessage);
        await _context.SaveChangesAsync();
        await _loggerServie.SaveNewlog(User.Identity.Name, "Send Message");
        return new GeneralServiceResponseDto()
        {
            IsSucced = true,
            StatusCode = 201,
            Message = "Message Save Successfully"
        };
    }

    public async Task<IEnumerable<GetMessageDto>> GetMessageAsync()
    {
        var messages = await _context.Messages
            .Select(x => new GetMessageDto()
            {
                Id = x.Id,
                SenderUserName = x.SenderUserName,
                ReceiverUserName = x.ReceiverUserName,
                Text = x.Text,
                CreateAt = x.CreatedAt
            })
            .OrderByDescending(x => x.CreateAt)
            .ToListAsync();
        return messages;
    }

    public async Task<IEnumerable<GetMessageDto>> GetMyMessageAsync(ClaimsPrincipal User)
    {
        var loggerInUser = User.Identity.Name;
        var messages = await _context.Messages
            .Where(x => x.SenderUserName == loggerInUser
                   || x.ReceiverUserName == loggerInUser)
            .Select(x => new GetMessageDto()
            {
                Id = x.Id,
                SenderUserName = x.SenderUserName,
                ReceiverUserName = x.ReceiverUserName,
                Text = x.Text,
                CreateAt = x.CreatedAt
            })
            .OrderByDescending(x => x.CreateAt)
            .ToListAsync();
        return messages;
    }
}
