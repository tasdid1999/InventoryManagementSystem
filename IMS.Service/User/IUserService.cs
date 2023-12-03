
using IMS.Entity.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Service.User
{
    public interface IUserService
    {
        Task<bool> IsEmailExistAsync(string email);

        Task<bool> IsUserExistAsync(string email, string password);

        Task<bool> IsUserExistAsync(string email);
        Task<UserForToken> GetUserForTokenAsync(string email);

        Task<bool> IsRoleExist(string role);
    }
}
