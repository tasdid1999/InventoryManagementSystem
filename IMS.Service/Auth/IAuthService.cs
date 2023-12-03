using IMS.ClientEntity.Auth;
using IMS.Entity.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Auth
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterRequest user);

        Task<bool> LoginAsync(LoginRequest user);
        string GetJwtToken(UserForToken user);
    }
}
