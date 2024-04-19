using System.Security.Claims;

namespace SimpleAuthNet.Services;

public partial class UserService
{
    public async Task<AppResponse<bool>> UserLogoutAsync(ClaimsPrincipal user)
    {
        if (user.Identity?.IsAuthenticated ?? false)
        {
            var username = user.Claims.First(x => x.Type == "UserName").Value;
            var appUser = applicationDbContext.Users.FirstOrDefault(x => x.UserName == username);
            if (appUser != null) { await userManager.UpdateSecurityStampAsync(appUser); }
            return new AppResponse<bool>().SetSuccessResponse(true);
        }
        return new AppResponse<bool>().SetSuccessResponse(true);
    }
}