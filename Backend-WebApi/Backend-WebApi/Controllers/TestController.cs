using Backend_WebApi.Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet]
    [Route("get-public")]
    public IActionResult GetPublicData()
    {
        return Ok("Public data");
    }
    [HttpGet]
    [Route("get-user-role")]
    [Authorize(Roles =StaticUserRoles.USER)]
    public IActionResult GetUserData()
    {
        return Ok("User Role Data");
    }

    [HttpGet]
    [Route("get-mamager-role")]
    [Authorize(Roles = StaticUserRoles.MANAGER)]
    public IActionResult GetMamagerData()
    {
        return Ok("Mamager Role Data");
    }

    [HttpGet]
    [Route("get-admin-role")]
    [Authorize(Roles = StaticUserRoles.ADMIN)]
    public IActionResult GetAdminData()
    {
        return Ok("Admin Role Data");
    }
    [HttpGet]
    [Route("get-owner-role")]
    [Authorize(Roles = StaticUserRoles.OWNER)]
    public IActionResult GetOwnerData()
    {
        return Ok("Owner Role Data");
    }
}
