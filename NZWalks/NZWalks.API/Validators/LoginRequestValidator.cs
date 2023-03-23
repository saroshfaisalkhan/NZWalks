﻿using FluentValidation;
using NZWalks.API.Models.DTO;
using System.Data;

namespace NZWalks.API.Validators
{
    public class LoginRequestValidator:AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x=>x.Password).NotEmpty();
        }
    }
}
