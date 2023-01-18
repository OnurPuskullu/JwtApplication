using JwtApplication.Back.Core.Application.Dto;
using MediatR;

namespace JwtApplication.Back.Core.Application.Features.CQRS.Queries
{
    public class GetCategoriesQueryRequest : IRequest<List<CategoryListDto>>
    {
    }
}
