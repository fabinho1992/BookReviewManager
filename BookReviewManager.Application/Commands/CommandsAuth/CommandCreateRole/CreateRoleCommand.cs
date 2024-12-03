using BookReviewManager.Application.Dtos;
using BookReviewManager.Domain.ModelsAutentication;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.CommandsAuth.CommandCreateRole
{
    public class CreateRoleCommand : IRequest<ResultViewModel<ResponseIdentityCreate>>
    {
        public CreateRoleCommand(string roleName)
        {
            RoleName = roleName;
        }

        public string RoleName { get; private set; }
    }
}
