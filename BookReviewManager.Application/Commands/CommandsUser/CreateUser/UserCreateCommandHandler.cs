using BookReviewManager.Application.Dtos;
using BookReviewManager.Domain.Entities;
using BookReviewManager.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.CommandsUser.CreateUser
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, ResultViewModel<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserCreateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<int>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var newUser = new User(request.Name, request.Email);

            await _unitOfWork.UserRepository.CreateAsync(newUser);
            await _unitOfWork.Commit();

            return ResultViewModel<int>.Success(newUser.Id);
        }
    }
}
