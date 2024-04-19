using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleAuthNet.Services;
using SimpleAuthNet.Services.User;

namespace SimpleAuthNet.Controllers;


[ApiController]
[Route("[controller]/[action]")]
public class UserController(UserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<AppResponse<bool>> Register(UserRegisterRequest req)
    {
        return await userService.UserRegisterAsync(req);
    }

    [HttpPost]
    public async Task<AppResponse<UserLoginResponse>> Login(UserLoginRequest req)
    {
        return await userService.UserLoginAsync(req);
    }

    [HttpPost]
    public async Task<AppResponse<UserRefreshTokenResponse>> RefreshToken(UserRefreshTokenRequest req)
    {
        return await userService.UserRefreshTokenAsync(req);
    }
    [HttpPost]
    public async Task<AppResponse<bool>> Logout()
    {
        return await userService.UserLogoutAsync(User);
    }

    [HttpPost]
    [Authorize]
    public string Profile()
    {
        return User.FindFirst("UserName")?.Value ?? "";
    }
}