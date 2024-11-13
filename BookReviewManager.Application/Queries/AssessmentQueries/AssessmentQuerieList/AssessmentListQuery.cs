using BookReviewManager.Application.Dtos;
using BookReviewManager.Application.Dtos.ViewModels.AssessmentViewsModel;
using BookReviewManager.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Queries.AssessmentQueries.AssessmentQuerieList
{
    public class AssessmentListQuery : ParametrosPaginacao, IRequest<ResultViewModel<List<AssessmentResponseAll>>>
    {
        public AssessmentListQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
