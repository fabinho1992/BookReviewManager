using BookReviewManager.Application.Dtos;
using BookReviewManager.Application.Dtos.ViewModels.AssessmentViewsModel;
using BookReviewManager.Application.Dtos.ViewModels.UserViewsModel;
using BookReviewManager.Domain.Errors;
using BookReviewManager.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Queries.UserQueries.UserQueriesById
{
    public class UserByIdQueryHandler : IRequestHandler<UserByIdQuery, ResultViewModel<UserResponseAll>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<UserResponseAll>> Handle(UserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
            if (user is null)
            {
                return ResultViewModel<UserResponseAll>.Error(UserError.Notfound.ToString());
            }

            var listAssessment = new List<AssessmentResponseToUser>();
            foreach (var item in user.Assessments)
            {
                var assessment = new AssessmentResponseToUser(item.Nota, item.Description, item.AssessmentDate.ToString("d"), item.Book.Title);
                listAssessment.Add(assessment);
            }


            var userResponse = new UserResponseAll(user.Name, user.Email, listAssessment); 
            
            return ResultViewModel<UserResponseAll>.Success(userResponse);
            
        }
    }
}
