using BookReviewManager.Application.Dtos;
using BookReviewManager.Domain.Entities;
using BookReviewManager.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.CommandAssessment.CreateAssessment
{
    public class AssessmentCreateCommandHandler : IRequestHandler<AssessmentCreateCommand, ResultViewModel<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssessmentCreateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<int>> Handle(AssessmentCreateCommand request, CancellationToken cancellationToken)
        {
            var assessment = new Assessment(request.Nota, request.Description, request.UserId, request.BookId);

            await _unitOfWork.AssessmentRepository.CreateAsync(assessment);
            await _unitOfWork.Commit();

            return ResultViewModel<int>.Success(assessment.Id);
        }
    }
}
