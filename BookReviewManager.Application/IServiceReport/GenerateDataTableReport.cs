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
        public void DataTableReportDonors(IEnumerable<Assessment> assessments, WebReport webReport)
        {
            var assessmentDataTable = new DataTable();

            assessmentDataTable.Columns.Add("Note", typeof(int));
            assessmentDataTable.Columns.Add("Assessment Date", typeof(string));
            assessmentDataTable.Columns.Add("Quantity ml", typeof(string));


            foreach (var item in bloodStocks)
            {
                donationsDataTable.Rows.Add(item.BloodType, item.FactorRh, item.QuantityMl);
            }

            webReport.Report.RegisterData(donationsDataTable, "Blood Stock Report");
        }
    }
}
