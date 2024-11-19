using BookReviewManager.Application.IServiceReport;
using BookReviewManager.Application.Queries.ReportsQueries;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IGenerateDataTableReport _generateDataTableReport;

        public ReportsController(IMediator mediator, IWebHostEnvironment webHostEnvironment, 
            IGenerateDataTableReport generateDataTableReport)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
            _generateDataTableReport = generateDataTableReport;
        }

        [HttpGet]
        public async Task<IActionResult> AssessmentsReport()
        {
            var donations = new AssessmentReportQuery();
            if (donations is null)
            {
                return NotFound();
            }
            var result = await _mediator.Send(donations);

            var webReport = new WebReport();
            webReport.Report.Load(Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "AssessmentsReports.frx"));

            _generateDataTableReport.DataTableReportAssessment(result, webReport);

            webReport.Report.Prepare();

            using MemoryStream stream = new MemoryStream();
            webReport.Report.Export(new PDFSimpleExport(), stream);
            stream.Flush();
            byte[] arrayReport = stream.ToArray();
            return File(arrayReport, "application/zip", "AssessmentsReports.pdf");
        }
    }
}
