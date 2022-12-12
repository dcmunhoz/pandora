using AutoMapper;
using Pandora.Application.Business.Authentication.Commands.Login;
using Pandora.Application.Business.Authentication.Commands.Register;
using Pandora.Application.Business.Authentication.Results;
using Pandora.Application.Dto.Authentication.Requests;
using Pandora.Application.Dto.Authentication.Responses;
using Pandora.Application.Services.Cryptography;
using Pandora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Application.Mapper
{
    public class AuthenticationMap: Profile
    {
        public AuthenticationMap()
        {
            // Register
            CreateMap<RegisterNewUserRequest, RegisterNewUserCommand>();
            CreateMap<User, UserRegistredResult>();
            CreateMap<UserRegistredResult, RegisterNewUserResponse>();

            // Login
            CreateMap<LoginRequest, LoginCommand>();
            CreateMap<UserAuthenticatedResult, UserAuthenticatedResponse>();
        }
    }
}
