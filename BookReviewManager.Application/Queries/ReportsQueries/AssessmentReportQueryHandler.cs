using BookReviewManager.Domain.Entities;
using BookReviewManager.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Queries.ReportsQueries
{
    public class AssessmentReportQueryHandler : IRequestHandler<AssessmentReportQuery, IEnumerable<Assessment>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssessmentReportQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Assessment>> Handle(AssessmentReportQuery request, CancellationToken cancellationToken)
        {
            var assessments = await _unitOfWork.AssessmentRepository.GetAllReport();
            return assessments;
        }
    }
}
