using BookReviewManager.Application.Dtos;
using BookReviewManager.Domain.IServices.Autentication;
using BookReviewManager.Domain.ModelsAutentication;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.CommandsAuth.CommandAddRole
{
    public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, ResultViewModel<ResponseIdentityCreate>>
    {
        private readonly IAddRole _addRole;

        public AddRoleCommandHandler(IAddRole addRole)
        {
            _addRole = addRole;
        }

        public async Task<ResultViewModel<ResponseIdentityCreate>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _addRole.AdicionarRoles(request.UserEmail, request.NameRole);

            return ResultViewModel<ResponseIdentityCreate>.Success(result);

        }
    }
}
