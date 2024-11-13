using BookReviewManager.Application.Dtos;
using BookReviewManager.Application.Dtos.ViewModels.AssessmentViewsModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Queries.AssessmentQueries.AssessmentQuerieByUser
{
    public class AssessmentByUserQuery : IRequest<ResultViewModel<List<AssessmentResponseToUser>>>
    {
        public AssessmentByUserQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
