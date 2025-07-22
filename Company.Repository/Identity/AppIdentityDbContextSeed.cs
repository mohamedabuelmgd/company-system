using Company.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Identity
{
    public class AppIdentityDbContextSeed
    {
         public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    DisplayName = "Mohamed Abuelmgd",
                    Email = "mohamedabuelmgd@gemail.com",
                    UserName = "mohamedabuelmgd",
                    PhoneNumber = "01159304056"

                };
                var result = await userManager.CreateAsync(user, "4@M@el@S@eny");
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"Error: {error.Description}");
                    }
                }
                
            }
        }
    }
}
