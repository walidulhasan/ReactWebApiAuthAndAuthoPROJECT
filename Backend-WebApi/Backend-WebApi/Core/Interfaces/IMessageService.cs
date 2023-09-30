using Backend_WebApi.Core.Dtos.General;
using Backend_WebApi.Core.Dtos.Message;
using System.Security.Claims;

namespace Backend_WebApi.Core.Interfaces;

public interface IMessageService
{
    Task<GeneralServiceResponseDto> CreateNewMessageAsync(ClaimsPrincipal User, CreateMessageDto createMessageDto);
    Task<IEnumerable<GetMessageDto>> GetMessageAsync();
    Task<IEnumerable<GetMessageDto>> GetMyMessageAsync(ClaimsPrincipal User);
}
