using BookReviewManager.Application.Dtos;
using BookReviewManager.Domain.Errors;
using BookReviewManager.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.CommandsUser.UpadateUser
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, ResultViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserUpdateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
            if(user is null)
            {
                return ResultViewModel.Error(UserError.Notfound.ToString());
            }

            user.Update(request.Name, request.Email);
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.Commit();

            return ResultViewModel.Success();

        }
    }
}
