using BookReviewManager.Domain.IServices;
using BookReviewManager.Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiGoogleBooksController : ControllerBase
    {
        private readonly IGoogleBookApi _googleapi;

        public ApiGoogleBooksController(IGoogleBookApi googleapi)
        {
            _googleapi = googleapi;
        }

        [HttpGet]
        public async Task<IActionResult> SearchBooks(string query, int maxResults)
        {
            

            var book = await _googleapi.SearchBooksAsync(query, maxResults);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
    }
}
