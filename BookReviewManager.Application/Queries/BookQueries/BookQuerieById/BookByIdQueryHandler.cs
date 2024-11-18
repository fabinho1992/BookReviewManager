using BookReviewManager.Application.Dtos;
using BookReviewManager.Application.Dtos.ViewModels.AssessmentViewsModel;
using BookReviewManager.Application.Dtos.ViewModels.BookViewsModel;
using BookReviewManager.Domain.Errors;
using BookReviewManager.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Queries.BookQueries.BookQuerieById
{
    public class BookByIdQueryHandler : IRequestHandler<BookByIdQuery, ResultViewModel<BookResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<BookResponse>> Handle(BookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetByIdAsync(request.Id);
            if (book is null)
            {
                return ResultViewModel<BookResponse>.Error(BookError.Notfound.ToString());
            }

            var assessment = new List<AssessmentResponseToBook>();
            foreach (var item in book.Assessments)
            {
                var assessmentResponse = new AssessmentResponseToBook(item.Nota, item.Description, 
                    item.AssessmentDate.ToString("d"), item.User.Name);
                assessment.Add(assessmentResponse);
            }

            var bookResponse = new BookResponse(book.Title, book.Description, book.Author, book.ISBN, 
                book.Publisher, book.GenerBook, book.YearPublication, book.NumberPages, book.MedianaNota, assessment);

            return ResultViewModel<BookResponse>.Success(bookResponse);
        }
    }
}
