using AutoMapper;
using JwtApplication.Back.Core.Application.Dto;
using JwtApplication.Back.Core.Application.Features.CQRS.Queries;
using JwtApplication.Back.Core.Application.Interfaces;
using JwtApplication.Back.Core.Domain;
using MediatR;

namespace JwtApplication.Back.Core.Application.Features.CQRS.Handlers
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
            var result = await this.repository.GetByFilterAsync(x => x.Id == request.Id);
            return this.mapper.Map<CategoryListDto>(result);
        }
    }
}
