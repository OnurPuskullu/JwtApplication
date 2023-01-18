using AutoMapper;
using JwtApplication.Back.Core.Application.Dto;
using JwtApplication.Back.Core.Domain;

namespace JwtApplication.Back.Core.Application.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            this.CreateMap<Category, CategoryListDto>().ReverseMap();
        }
    }
}
