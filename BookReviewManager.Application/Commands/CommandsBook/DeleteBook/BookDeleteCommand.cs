using BookReviewManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.CommandsBook.DeleteBook
{
    public class BookDeleteCommand : IRequest<ResultViewModel>
    {
        public BookDeleteCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
