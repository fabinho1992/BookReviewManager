using BookReviewManager.Application.Dtos;
using BookReviewManager.Application.Dtos.ViewModels.AssessmentViewsModel;
using BookReviewManager.Domain.Errors;
using BookReviewManager.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Queries.AssessmentQueries.AssessmentQuerieById
{
    public class AssessmentByIdQueryHandler : IRequestHandler<AssessmentByIdQuery, ResultViewModel<AssessmentResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssessmentByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<AssessmentResponse>> Handle(AssessmentByIdQuery request, CancellationToken cancellationToken)
        {
            var assessment = await _unitOfWork.AssessmentRepository.GetByIdAsync(request.Id);
            if(assessment is null)
            {
                return ResultViewModel<AssessmentResponse>.Error(AssessmentError.Notfound.ToString());
            }

            var assessmentResponse = new AssessmentResponse(assessment.Nota, assessment.Description, 
                assessment.User.Name, assessment.Book.Title, assessment.AssessmentDate.ToString("d"));

            return ResultViewModel<AssessmentResponse>.Success(assessmentResponse);
        }
    }
}
