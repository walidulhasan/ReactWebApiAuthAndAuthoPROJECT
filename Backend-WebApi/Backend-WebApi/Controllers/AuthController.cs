using Backend_WebApi.Core.Constants;
using Backend_WebApi.Core.Dtos.Auth;
using Backend_WebApi.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend_WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;


    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    //Route -> Seed Roles to DB
    [HttpPost]
    [Route("seed-roles")]
    public async Task<IActionResult> SeedRoles()
    {
        var seedResult = await _authService.SeedRolesAsync();
        return StatusCode(seedResult.StatusCode, seedResult.Message);
    }
    //Route -> Register
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var registerResutl = await _authService.RegisterAsync(registerDto);
        return StatusCode(registerResutl.StatusCode, registerResutl.Message);
    }
    //Route -> Login
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<LoginServiceResponseDto>> Login([FromBody] LoginDto loginDto)
    {
        var loginResutl = await _authService.LoginAsync(loginDto);
        if (loginResutl is null)
        {
            return Unauthorized("Your credentials are invalid .Please contact to an admin");
        }
        return Ok(loginResutl);
    }

    //Route -> Update User Role
    //An Owner can change everythin
    //An admin can change just User to Manager or reverse
    //Manager and User Roles don't have access to this Route
    [HttpPost]
    [Route("update-role")]
    [Authorize(Roles = StaticUserRoles.OwnerAdmin)]
    public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleDto updateRoleDto)
    {
        var updateRoleResult = await _authService.UpdateRoleAsync(User, updateRoleDto);
        if (updateRoleResult.IsSucced)
        {
            return Ok(updateRoleResult.Message);
        }
        else
        {
            return StatusCode(updateRoleResult.StatusCode, updateRoleResult.Message);
        }
    }

    //Route -> getting data of a user from it's JWT
    [HttpPost]
    [Route("me")]
    public async Task<ActionResult<LoginServiceResponseDto>> Me([FromBody] MeDto meDto)
    {
        try
        {
            var me = await _authService.MeAsync(meDto);
            if (me is not null)
            {
                return Ok(me);
            }
            else
            {
                return Unauthorized("Invalid Token");
            }
        }
        catch (Exception)
        {

            return Unauthorized("Invalid Token");
        }
    }

    //Route -> List of all users with details
    [HttpGet]
    [Route("users")]
    public async Task<ActionResult<IEnumerable<UserInfoResult>>> GetUsersList()
    {
        var usersList = await _authService.GetUsersListAsync();
        return Ok(usersList);
    }
    //Route -> Get a User by User Name
    [HttpGet]
    [Route("users/{userName}")]
    public async Task<ActionResult<UserInfoResult>> GetUserDetailsByUserName([FromBody] string userName)
    {
        var user = await _authService.GetUserDetailsByUserNameAsync(userName);
        if (user is not null)
        {
            return Ok(user);
        }
        else
        {
            return NotFound($"UserName not found {userName}");
        }
    }

    //Route -> Get List of all usernames for send message
    [HttpGet]
    [Route("usernames")]
    public async Task<ActionResult<IEnumerable<string>>> GetUserNameList()
    {
        var usernames = await _authService.GetUserNamesListAsync();
        return Ok(usernames);
    }

}
