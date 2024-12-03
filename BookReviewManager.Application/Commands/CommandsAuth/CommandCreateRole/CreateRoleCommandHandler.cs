using BookReviewManager.Application.Dtos;
using BookReviewManager.Domain.IServices.Autentication;
using BookReviewManager.Domain.ModelsAutentication;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.CommandsAuth.CommandCreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, ResultViewModel<ResponseIdentityCreate>>
    {
        private readonly ICreateRole _createRole;

        public CreateRoleCommandHandler(ICreateRole createRole)
        {
            _createRole = createRole;
        }

        public async Task<ResultViewModel<ResponseIdentityCreate>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _createRole.CreateRoleAsync(request.RoleName);
            return ResultViewModel<ResponseIdentityCreate>.Success(result);
        }
    }
}
