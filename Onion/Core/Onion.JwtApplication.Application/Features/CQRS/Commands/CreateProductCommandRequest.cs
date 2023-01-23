﻿using MediatR;
using Onion.JwtApplication.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApplication.Application.Features.CQRS.Commands
{
    public class CreateProductCommandRequest : IRequest<CreatedProductDto?>
    {
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
