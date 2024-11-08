using BookReviewManager.Application.Dtos;
using BookReviewManager.Domain.Errors;
using BookReviewManager.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.CommandsBook.DeleteBook
{
    public class BookDeleteCommandHandler : IRequestHandler<BookDeleteCommand, ResultViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookDeleteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel> Handle(BookDeleteCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetByIdAsync(request.Id);
            if (book is null)
            {
                return ResultViewModel.Error(BookError.Notfound.ToString());
            }

            await _unitOfWork.BookRepository.Delete(book);
            await _unitOfWork.Commit();

            return ResultViewModel.Success();
        }
    }
}
