using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleAuthNet.Models.Entities;

namespace SimpleAuthNet.Data;

public class ApplicationDbContextInitialiser(
    ILogger<ApplicationDbContextInitialiser> logger,
    ApplicationDbContext context,
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager)
    {
        public async Task InitialiseAsync()
        {
            try
            {
                if (context.Database.IsSqlite())
                {
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }
        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        private async Task TrySeedAsync()
        {
            // Default roles
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                var role = await roleManager.CreateAsync(administratorRole);
                if (role != null)
                {
                    await roleManager.AddClaimAsync(administratorRole, new Claim("RoleClaim", "HasRoleView"));
                    await roleManager.AddClaimAsync(administratorRole, new Claim("RoleClaim", "HasRoleAdd"));
                    await roleManager.AddClaimAsync(administratorRole, new Claim("RoleClaim", "HasRoleEdit"));
                    await roleManager.AddClaimAsync(administratorRole, new Claim("RoleClaim", "HasRoleDelete"));
                }
            }

            // Default users
            var administrator = new ApplicationUser { UserName = "UnifiedAppAdmin", Email = "UnifiedAppAdmin", BirthDate = new DateTime(2000, 1, 1) };
            
            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "UnifiedAppAdmin1!");
                if (!string.IsNullOrWhiteSpace(administratorRole.Name))
                {
                    await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
                }
            }
        }
    }