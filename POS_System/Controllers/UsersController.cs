using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("admins")]
    public async Task<IActionResult> GetAdmins()
    {
        var list = await _userService.GetUsers("ADMIN");
        return Ok(list);
    }

    [HttpGet("sellers")]
    public async Task<IActionResult> GetSellers()
    {
        var list = await _userService.GetUsers("SELLER");
        return Ok(list);
    }
}
