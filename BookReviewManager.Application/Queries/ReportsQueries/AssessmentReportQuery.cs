using BookReviewManager.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Queries.ReportsQueries
{
    public class AssessmentReportQuery : IRequest<IEnumerable<Assessment>>
    {
    }
}
