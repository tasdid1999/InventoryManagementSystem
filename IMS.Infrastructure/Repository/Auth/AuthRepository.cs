using IMS.ClientEntity.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public AuthRepository() { }
        public AuthRepository(UserManager<IdentityUser<int>> userManager,
                             SignInManager<IdentityUser<int>> signInManager,
                             RoleManager<IdentityRole<int>> roleManager

                             )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }

        public async Task<bool> LoginAsync(LoginRequest user)
        {

            var dbActionResult = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, false);

            return dbActionResult.Succeeded ? true : false;
        }

        public async Task<bool> RegisterAsync(RegisterRequest user)
        {
            try
            {
                var identityUser = new IdentityUser<int>()
                {

                    UserName = user.Email,
                    Email = user.Email,
                };


                var dbActionResult = await _userManager.CreateAsync(identityUser, user.Password);
                if (dbActionResult.Succeeded)
                {
                    var newUser = await _userManager.FindByEmailAsync(identityUser.Email);

                    await _userManager.AddToRoleAsync(newUser, user.Role);

                }

                return dbActionResult.Succeeded ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }
}


