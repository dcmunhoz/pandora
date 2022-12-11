using AutoMapper;
using Pandora.Application.Business.Authentication.Commands.Register;
using Pandora.Application.Business.Authentication.Results;
using Pandora.Application.Dto.Authentication.Requests;
using Pandora.Application.Dto.Authentication.Responses;
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
            CreateMap<RegisterNewUserRequest, RegisterNewUserCommand>();
            CreateMap<User, UserRegistredResult>();
            CreateMap<UserRegistredResult, RegisterNewUserResponse>();
        }
    }
}
