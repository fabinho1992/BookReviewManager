using BookReviewManager.Application.Dtos.ViewModels.UserViewsModel;
using BookReviewManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReviewManager.Domain.IRepositories;
using BookReviewManager.Domain.Errors;

namespace BookReviewManager.Application.Queries.UserQueries.UserQuerieList
{
    public class UserListQueryHandler : IRequestHandler<UserListQuery, ResultViewModel<List<UserResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<List<UserResponse>>> Handle(UserListQuery request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync(request);

            if (users is null)
            {
                return ResultViewModel<List<UserResponse>>.Error(UserError.Notfound.ToString());
            }

            var usersResponse = new List<UserResponse>();
            foreach (var item in users)
            {
                var newUser = new UserResponse(item.Name, item.Email);
                usersResponse.Add(newUser);
            }

            return ResultViewModel<List<UserResponse>>.Success(usersResponse);
        }
    }
}
