using AutoMapper;
using Onion.JwtApplication.Application.Dto;
using Onion.JwtApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApplication.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<Product, ProductListDto>().ReverseMap();
            this.CreateMap<Product, CreatedProductDto>().ReverseMap();
        }
    }
}
