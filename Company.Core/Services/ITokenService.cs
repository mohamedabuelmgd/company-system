using Company.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Company.Core.Services
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user,UserManager<AppUser> userManager);
    }
}
