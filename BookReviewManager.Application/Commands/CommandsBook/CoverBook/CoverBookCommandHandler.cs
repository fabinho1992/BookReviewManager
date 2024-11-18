using BookReviewManager.Application.Dtos;
using BookReviewManager.Domain.Errors;
using BookReviewManager.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.CommandsBook.CoverBook
{
    public class CoverBookCommandHandler : IRequestHandler<CoverBookCommand, ResultViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel> Handle(CoverBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetByIdAsync(request.Id);
            if(book is null)
            {
                return ResultViewModel.Error(BookError.Notfound.ToString());
            }

            byte[] imageBytes;
            using (var memoryStream = new MemoryStream())
            {
                await request.Cover.CopyToAsync(memoryStream);
                imageBytes = memoryStream.ToArray();
            }

            book.AddCover(imageBytes);

            _unitOfWork.BookRepository.Update(book);
            await _unitOfWork.Commit();

            return ResultViewModel.Success();
        }
    }
}
