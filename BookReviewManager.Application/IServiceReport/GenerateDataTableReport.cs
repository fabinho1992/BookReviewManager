using BookReviewManager.Domain.Entities;
using FastReport.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.IServiceReport
{
    public class GenerateDataTableReport : IGenerateDataTableReport
    {
        public void DataTableReportAssessment(IEnumerable<Assessment> assessments, WebReport webReport)
        {
            var assessmentDataTable = new DataTable();

            assessmentDataTable.Columns.Add("Note", typeof(int));
            assessmentDataTable.Columns.Add("User Name", typeof(string));
            assessmentDataTable.Columns.Add("Title Book", typeof(string));


            foreach (var item in assessments)
            {
                assessmentDataTable.Rows.Add(item.Nota, item.User.Name, item.Book.Title);
            }

            webReport.Report.RegisterData(assessmentDataTable, "Blood Stock Report");
        }
    }
}
