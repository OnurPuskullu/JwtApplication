using MediatR;
using Onion.JwtApplication.Application.Features.CQRS.Commands;
using Onion.JwtApplication.Application.Interfaces;
using Onion.JwtApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwtApplication.Application.Features.CQRS.Handlers
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest>
    {
        private readonly IRepository<Product> repository;

        public RemoveProductCommandHandler(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            var removedEntity = await this.repository.GetByIdAsync(request.Id);
            if (removedEntity != null)
            {
                await this.repository.Remove(removedEntity);
            }
            return Unit.Value;
        }
    }
}
