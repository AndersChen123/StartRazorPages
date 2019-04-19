using StartRazorPages.Domain;
using StartRazorPages.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StartRazorPages.Persistence
{
    public class DataSeed
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            try
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

                    if (!context.Tenants.Any())
                    {
                        context.Tenants.Add(new Tenant { Host = "https://localhost:44392/", Name = "demo1", ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=aspnet-StartRazorPages-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=True;MultipleActiveResultSets=true" });

                        await context.SaveChangesAsync();
                    }

                    var roles = new[] { "Admin", "User" };

                    var roleManager = scope.ServiceProvider.GetService<RoleManager<ApplicationRole>>();
                    foreach (var role in roles)
                    {
                        if (!context.Roles.Any(r => r.Name == role))
                        {
                            await roleManager.CreateAsync(new ApplicationRole { Name = role });
                        }
                    }

                    var user = new ApplicationUser
                    {
                        TenantId = 1,
                        Email = "test@example.com",
                        UserName = "demouser",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D")
                    };


                    if (!context.Users.Any(u => u.UserName == user.UserName))
                    {
                        var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
                        await userManager.CreateAsync(user, "123456");

                        var admin = await userManager.FindByNameAsync("demouser");
                        await userManager.AddToRoleAsync(admin, "Admin");
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                throw;
#endif
            }
        }
    }
}
