﻿using JwtApplication.Back.Core.Application.Features.CQRS.Commands;
using JwtApplication.Back.Core.Application.Interfaces;
using JwtApplication.Back.Core.Domain;
using MediatR;

namespace JwtApplication.Back.Core.Application.Features.CQRS.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest>
    {
        private readonly IRepository<Category> repository;

        public DeleteCategoryCommandHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await this.repository.GetByIdAsync(request.Id);
            if (deletedEntity != null)
            {
                await this.repository.RemoveAsync(deletedEntity);
            }
            return Unit.Value;
        }
    }
}
