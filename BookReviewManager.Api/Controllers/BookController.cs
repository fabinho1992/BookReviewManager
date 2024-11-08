using BookReviewManager.Application.Commands.CommandsBook.CreateBook;
using BookReviewManager.Application.Commands.CommandsBook.DeleteBook;
using BookReviewManager.Application.Commands.CommandsBook.UpdateBook;
using BookReviewManager.Domain.Entities;
using BookReviewManager.Domain.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<IActionResult> Create(BookCreateCommand command)
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

            return Ok();
        }

        [HttpPut] 
        public async Task<IActionResult> Update(BookUpdateCommand command)
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

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var book = new BookDeleteCommand(id);
            var result = await _mediator.Send(book);
            if (!result.IsSuccess)
            {
                BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
