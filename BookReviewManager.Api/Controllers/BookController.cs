using BookReviewManager.Domain.Entities;
using BookReviewManager.Domain.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            await _unitOfWork.BookRepository.CreateAsync(book);
            await _unitOfWork.Commit();

            return Ok();
        }
    }
}
