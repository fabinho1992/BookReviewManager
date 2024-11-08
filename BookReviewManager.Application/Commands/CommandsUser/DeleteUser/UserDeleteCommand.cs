using BookReviewManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.CommandsUser.DeleteUser
{
    public class UserDeleteCommand : IRequest<ResultViewModel>
    {
        public UserDeleteCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
