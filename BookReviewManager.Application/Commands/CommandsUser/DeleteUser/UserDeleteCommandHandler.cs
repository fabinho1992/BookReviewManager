using BookReviewManager.Application.Dtos;
using BookReviewManager.Domain.Errors;
using BookReviewManager.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.CommandsUser.DeleteUser
{
    public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommand, ResultViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserDeleteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
            if(user is null)
            {
                return ResultViewModel.Error(UserError.Notfound.ToString());
            }

            await _unitOfWork.UserRepository.Delete(user);
            await _unitOfWork.Commit();

            return ResultViewModel.Success();

        }
    }
}
