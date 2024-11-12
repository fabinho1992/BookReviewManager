using BookReviewManager.Application.Dtos;
using BookReviewManager.Application.Dtos.ViewModels.BookViewsModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Queries.BookQueries.BookQuerieById
{
    public class BookByIdQuery : IRequest<ResultViewModel<BookResponse>>
    {
        public BookByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
