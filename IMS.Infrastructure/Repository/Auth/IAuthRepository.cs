using IMS.ClientEntity.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.Auth
{
    public interface IAuthRepository
    {
        Task<bool> LoginAsync(LoginRequest user);

        Task<bool> RegisterAsync(RegisterRequest user);

    }
}
