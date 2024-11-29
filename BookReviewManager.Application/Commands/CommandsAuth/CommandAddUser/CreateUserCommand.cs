using BookReviewManager.Application.Dtos;
using BookReviewManager.Domain.ModelsAutentication;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.CommandsAuth.CommandAddUser
{
    public class CreateUserCommand : IRequest<ResultViewModel<ResponseIdentityCreate>>
    {
        public CreateUserCommand(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
        }

        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
