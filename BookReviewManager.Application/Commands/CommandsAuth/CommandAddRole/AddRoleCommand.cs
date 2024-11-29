using BookReviewManager.Application.Dtos;
using BookReviewManager.Domain.ModelsAutentication;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.CommandsAuth.CommandAddRole
{
    public class AddRoleCommand : IRequest<ResultViewModel<ResponseIdentityCreate>>
    {
        public AddRoleCommand(string userEmail, string nameRole)
        {
            UserEmail = userEmail;
            NameRole = nameRole;
        }

        public string  UserEmail { get; private set; }
        public string NameRole { get; private set; }
    }
}
