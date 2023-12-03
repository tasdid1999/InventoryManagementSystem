using Ecom.Service.Token;
using IMS.ClientEntity.Auth;
using IMS.Entity.Helper;
using IMS.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.Auth
{
    public class AuthService : IAuthService
    {

       

        private readonly IUnitOfWork _unitOfWork;
        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public string GetJwtToken(UserForToken user)
        {
            var tokenFactory = new JwtTokenFactory();
            return tokenFactory.CreateJWT(user);

        }

        public Task<bool> LoginAsync(LoginRequest user)
        {
            return _unitOfWork.AuthRepository.LoginAsync(user);
        }

        public Task<bool> RegisterAsync(RegisterRequest user)
        {
            return _unitOfWork.AuthRepository.RegisterAsync(user);
        }
    }

    }
