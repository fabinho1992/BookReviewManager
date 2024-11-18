using BookReviewManager.Domain.Entities;
using FastReport.Web;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.IServiceReport
{
    public interface IGenerateDataTableReport
    {
        void DataTableReportDonors(IEnumerable<Assessment> assessments, WebReport webReport);
    }
}
