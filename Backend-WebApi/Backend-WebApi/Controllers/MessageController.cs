using Backend_WebApi.Core.Constants;
using Backend_WebApi.Core.Dtos.Message;
using Backend_WebApi.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;

    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    //Rout -> Create a new message to send to anoutehr user
    [HttpPost]
    [Route("create")]
    [Authorize]
    public async Task<IActionResult> CreateNewMessage([FromBody]CreateMessageDto createMessageDto)
    {
        var result = await _messageService.CreateNewMessageAsync(User, createMessageDto);
        if (result.IsSucced)
        {
            return Ok(result.Message);
        }
        return StatusCode(result.StatusCode, result.Message);
    }
    [HttpGet]
    [Route("mine")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<GetMessageDto>>> GetMyMessages()
    {
        var messages = await _messageService.GetMyMessageAsync(User);

        return Ok(messages);
    }

    //Rout -> Get all messages With Owner Access and admin access

    [HttpGet]
    [Authorize(Roles = StaticUserRoles.OwnerAdmin)]
    public async Task<ActionResult<IEnumerable<GetMessageDto>>> GetMessage()
    {
        var messages = await _messageService.GetMessageAsync();

        return Ok(messages);
    }

}
