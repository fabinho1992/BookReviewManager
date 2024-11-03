using BookReviewManager.Domain.Entities;
using BookReviewManager.Domain.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssessmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Assessment assessment)
        {
            await _unitOfWork.AssessmentRepository.CreateAsync(assessment);
            await _unitOfWork.Commit();

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var assessmentUser = await _unitOfWork.AssessmentRepository.GetOfUserAsync(id);

            return Ok(assessmentUser);
        }
    }
}
