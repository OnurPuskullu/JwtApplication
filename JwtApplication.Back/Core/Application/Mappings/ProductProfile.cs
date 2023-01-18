using AutoMapper;
using JwtApplication.Back.Core.Application.Dto;
using JwtApplication.Back.Core.Domain;

namespace JwtApplication.Back.Core.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<Product, ProductListDto>().ReverseMap();
        }
    }
}
