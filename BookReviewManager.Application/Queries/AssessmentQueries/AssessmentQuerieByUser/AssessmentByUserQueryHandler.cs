using BookReviewManager.Application.Dtos.ViewModels.AssessmentViewsModel;
using BookReviewManager.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReviewManager.Domain.IRepositories;
using BookReviewManager.Domain.Errors;

namespace BookReviewManager.Application.Queries.AssessmentQueries.AssessmentQuerieByUser
{
    public class AssessmentByUserQueryHandler : IRequestHandler<AssessmentByUserQuery, ResultViewModel<List<AssessmentResponseToUser>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssessmentByUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<List<AssessmentResponseToUser>>> Handle(AssessmentByUserQuery request, CancellationToken cancellationToken)
        {
            var assessment = await _unitOfWork.AssessmentRepository.GetOfUserAsync(request.Id);
            if (assessment is null)
            {
                return ResultViewModel<List<AssessmentResponseToUser>>.Error(AssessmentError.Notfound.ToString());
            }

            var assessmentResponse = new List<AssessmentResponseToUser>();
            foreach (var item in assessment)
            {
                var newAssessment = new AssessmentResponseToUser(item.Nota, item.Description, 
                    item.AssessmentDate.ToString("d"), item.Book.Title);
                assessmentResponse.Add(newAssessment);
            }

            return ResultViewModel<List<AssessmentResponseToUser>>.Success(assessmentResponse);

        }
    }
}
