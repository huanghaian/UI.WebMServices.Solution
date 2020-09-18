using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.UserIdentityServices.Models;

namespace UI.UserIdentityServices.Services
{
    public class LoginService : ILoginService<AppUser>
    {
        private UserManager<AppUser> _UserManager;
        private SignInManager<AppUser> _SignInManager;
        public LoginService(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _UserManager = userManager;
            _SignInManager = signInManager;
        }
        public async Task<bool> ValidateCredentials(AppUser user, string password)
        {
            return await _UserManager.CheckPasswordAsync(user, password);

        }

        public async Task<AppUser> FindByUsername(string user)
        {
            return await _UserManager.FindByEmailAsync(user);
        }

        public Task SignIn(AppUser user)
        {
            return _SignInManager.SignInAsync(user, true);
        }

        public  Task SignInAsync(AppUser user, AuthenticationProperties properties, string authenticationMethod = null)
        {
            return _SignInManager.SignInAsync(user, properties, authenticationMethod);

        }
    }
}
