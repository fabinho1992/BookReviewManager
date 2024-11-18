using BookReviewManager.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.CommandsBook.CoverBook
{
    public class CoverBookCommand : IRequest<ResultViewModel>
    {

        public CoverBookCommand(int id, IFormFile cover)
        {
            Id = id;
            Cover = cover;
        }

        public int Id { get; private set; }
        public IFormFile Cover { get; private set; }
    }
}
