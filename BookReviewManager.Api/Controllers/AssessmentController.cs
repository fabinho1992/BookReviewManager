using BookReviewManager.Application.Commands.CommandAssessment.CreateAssessment;
using BookReviewManager.Application.Queries.AssessmentQueries.AssessmentQuerieById;
using BookReviewManager.Application.Queries.AssessmentQueries.AssessmentQuerieByUser;
using BookReviewManager.Application.Queries.AssessmentQueries.AssessmentQuerieList;
using BookReviewManager.Domain.Entities;
using BookReviewManager.Domain.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AssessmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AssessmentCreateCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var query = new AssessmentByIdQuery(id);
            var result = await _mediator.Send(query);
            if (!result.IsSuccess) 
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]ParametrosPaginacao paginacao)
        {
            var query = new AssessmentListQuery(paginacao.PageNumber, paginacao.PageSize);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("ByUser")]
        public async Task<IActionResult> GetByUser(int id)
        {
            var query = new AssessmentByUserQuery(id);
            var result = await _mediator.Send(query);
            if (!result.IsSuccess) 
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
    }
}
