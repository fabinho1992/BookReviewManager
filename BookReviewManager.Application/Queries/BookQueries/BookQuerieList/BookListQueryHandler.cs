using BookReviewManager.Application.Dtos;
using BookReviewManager.Application.Dtos.ViewModels.BookViewsModel;
using BookReviewManager.Domain.Errors;
using BookReviewManager.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Queries.BookQueries.BookQuerieList
{
    public class BookListQueryHandler : IRequestHandler<BookListQuery, ResultViewModel<List<BookResponseAll>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<List<BookResponseAll>>> Handle(BookListQuery request, CancellationToken cancellationToken)
        {
            var books = await _unitOfWork.BookRepository.GetAllAsync(request);
            if (books is null)
            {
                return ResultViewModel<List<BookResponseAll>>.Error(BookError.Notfound.ToString());
            }

            var bookResponse = new List<BookResponseAll>();

            foreach (var item in books) 
            {
                var book = new BookResponseAll(item.Id, item.Title, item.Description, 
                    item.Author, item.GenerBook, item.YearPublication, item.NumberPages);
                bookResponse.Add(book);
            }

            return ResultViewModel<List<BookResponseAll>>.Success(bookResponse);

        }
    }
}
