using BookReviewManager.Application.Dtos;
using BookReviewManager.Application.Dtos.ViewModels.BookViewsModel;
using BookReviewManager.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Queries.BookQueries.BookQuerieList
{
    public class BookListQuery : ParametrosPaginacao, IRequest<ResultViewModel<List<BookResponseAll>>>
    {
        public BookListQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
