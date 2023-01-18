using JwtApplication.Back.Core.Application.Dto;
using MediatR;

namespace JwtApplication.Back.Core.Application.Features.CQRS.Queries
{
    public class GetCategoryQueryRequest : IRequest<CategoryListDto?>
    {
        public int Id { get; set; }
        public GetCategoryQueryRequest(int id)
        {
            Id= id;
        }
    }
}
