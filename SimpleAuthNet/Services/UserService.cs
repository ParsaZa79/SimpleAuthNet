using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using SimpleAuthNet.Data;
using SimpleAuthNet.Models.Entities;

namespace SimpleAuthNet.Services;

public partial class UserService(UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager,
    RoleManager<IdentityRole> roleManager,
    ApplicationDbContext applicationDbContext,
    TokenSettings tokenSettings)
{
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;

    private async Task<UserLoginResponse> GenerateUserToken(ApplicationUser user)
    {
        var claims = (from ur in applicationDbContext.UserRoles
                where ur.UserId == user.Id
                join r in applicationDbContext.Roles on ur.RoleId equals r.Id
                join rc in applicationDbContext.RoleClaims on r.Id equals rc.RoleId
                select rc)
            .Where(rc => rc.ClaimValue != null && rc.ClaimType != null)
            .Select(rc => new Claim(rc.ClaimType ?? "", rc.ClaimValue ?? ""))
            .Distinct()
            .ToList();
        var token = TokenUtil.GetToken(tokenSettings, user, claims);
        await userManager.RemoveAuthenticationTokenAsync(user, "REFRESHTOKEN", "RefreshToken");
        var refreshToken = await userManager.GenerateUserTokenAsync(user, "REFRESHTOKEN", "RefreshToken");
        await userManager.SetAuthenticationTokenAsync(user, "REFRESHTOKEN", "RefreshToken", refreshToken);
        return new UserLoginResponse() { AccessToken = token, RefreshToken = refreshToken };
    }

}