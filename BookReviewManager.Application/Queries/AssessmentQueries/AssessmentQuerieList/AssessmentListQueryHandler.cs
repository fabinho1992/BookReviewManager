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

namespace BookReviewManager.Application.Queries.AssessmentQueries.AssessmentQuerieList
{
    public class AssessmentListQueryHandler : IRequestHandler<AssessmentListQuery, ResultViewModel<List<AssessmentResponseAll>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssessmentListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<List<AssessmentResponseAll>>> Handle(AssessmentListQuery request, CancellationToken cancellationToken)
        {
            var assessments = await _unitOfWork.AssessmentRepository.GetAllAsync(request);
            if (assessments is null)
            {
                return ResultViewModel<List<AssessmentResponseAll>>.Error(AssessmentError.Notfound.ToString());
            }

            var assessmentsResponse = new List<AssessmentResponseAll>();
            foreach (var assessment in assessments) 
            {
                var newAssessment = new AssessmentResponseAll(assessment.Id, assessment.Nota, assessment.Description, assessment.User.Name,
                    assessment.Book.Title, assessment.AssessmentDate.ToString("d"));
                assessmentsResponse.Add(newAssessment);
            }   

            return ResultViewModel<List<AssessmentResponseAll>>.Success(assessmentsResponse);

        }
    }
}
