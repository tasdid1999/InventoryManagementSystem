using IMS.Entity.Helper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public UserRepository() { }
        public UserRepository(UserManager<IdentityUser<int>> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<UserForToken> GetUserForTokenAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var role = await _userManager.GetRolesAsync(user);


            return new UserForToken(user, role[0]);
        }

        public async Task<bool> IsEmailExistAsync(string email)
        {

            var user = await _userManager.FindByEmailAsync(email);

            return user is not null ? true : false;

        }

        public async Task<bool> IsRoleExist(string role)
        {
           return await  _roleManager.RoleExistsAsync(role);
        }

        public async Task<bool> IsUserExistAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
            {
                return false;
            }
            var isPasswordExist = await _userManager.CheckPasswordAsync(user, password);

            return user is not null && isPasswordExist ? true : false;

        }
        public async Task<bool> IsUserExistAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user is not null ? true : false;

        }
    }
}
