using BookReviewManager.Application.Dtos;
using BookReviewManager.Domain.Errors;
using BookReviewManager.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.CommandsBook.UpdateBook
{
    public class BookUpdateCommandHandler : IRequestHandler<BookUpdateCommand, ResultViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookUpdateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel> Handle(BookUpdateCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetByIdAsync(request.Id);
            if(book is null)
            {
                return ResultViewModel.Error(BookError.Notfound.ToString());
            }

            book.Update(request.Title, request.Description, request.Author, request.ISBN, request.Publisher, 
                request.GenerBook, request.YearPublication, request.NumberPages);

            _unitOfWork.BookRepository.Update(book);
            await _unitOfWork.Commit();

            return ResultViewModel.Success();
        }
    }
}
