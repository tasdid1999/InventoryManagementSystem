﻿using FluentValidation;
using IMS.ClientEntity.Auth;

namespace Ecom.API.Validator
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(user => user.Email).NotEmpty()
                                       .WithMessage("Email Required")
                                       .NotNull()
                                       .WithMessage("Email Required")
                                       .EmailAddress()
                                       .WithMessage("make sure its a valid email");

            RuleFor(user => user.Password).NotEmpty()
                                          .NotNull()
                                          .WithMessage("Password should be required")
                                          .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).{8,}$")
                                          .WithMessage("password should be contains atleast one uppercase , one lowercase, one digit,one special character and length atleast 8");


        }
    }
}
