using BookReviewManager.Application.Dtos;
using BookReviewManager.Domain.Entities;
using BookReviewManager.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.CommandsBook.CreateBook
{
    public class BookCreateCommandHandler : IRequestHandler<BookCreateCommand, ResultViewModel<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookCreateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<int>> Handle(BookCreateCommand request, CancellationToken cancellationToken)
        {
            var newBook = new Book(request.Title, request.Description, request.Author, request.ISBN, request.Publisher,
                request.GenerBook, request.YearPublication, request.NumberPages);

            await _unitOfWork.BookRepository.CreateAsync(newBook);
            await _unitOfWork.Commit();

            return ResultViewModel<int>.Success(newBook.Id);
        }
    }
}
