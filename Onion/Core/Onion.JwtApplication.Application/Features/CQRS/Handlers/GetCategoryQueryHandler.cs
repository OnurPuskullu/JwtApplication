﻿using AutoMapper;
using MediatR;
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
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, CategoryListDto?>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;

        public GetCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CategoryListDto?> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetByFilterAsync(x => x.Id == request.Id);
            return this.mapper.Map<CategoryListDto>(data);
        }
    }
}
