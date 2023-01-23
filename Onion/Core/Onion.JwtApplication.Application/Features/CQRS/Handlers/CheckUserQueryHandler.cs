﻿using MediatR;
using Onion.JwtApplication.Application.Dto;
using Onion.JwtApplication.Application.Features.CQRS.Queries;
using Onion.JwtApplication.Application.Interfaces;
using Onion.JwtApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApplication.Application.Features.CQRS.Handlers
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto?>
    {
        private readonly IRepository<AppUser> userRepository;
        private readonly IRepository<AppRole> roleRepository;

        public CheckUserQueryHandler(IRepository<AppUser> userRepository, IRepository<AppRole> roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<CheckUserResponseDto?> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();
            var user = await this.userRepository.GetByFilterAsync(x => x.Username == request.Username && x.Password == request.Password);
            if (user == null)
            {
                dto.IsExist= false;
            }
            else
            {
                dto.IsExist= true;
                dto.Username = user.Username;
                dto.Role = (await this.roleRepository.GetByFilterAsync(x => x.Id == user.AppRoleId))?.Definition;
                dto.Id = user.Id;
            }
            return dto;
        }
    }
}
