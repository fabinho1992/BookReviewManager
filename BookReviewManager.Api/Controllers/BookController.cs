using BookReviewManager.Application.Commands.CommandsBook.CoverBook;
using BookReviewManager.Application.Commands.CommandsBook.CreateBook;
using BookReviewManager.Application.Commands.CommandsBook.DeleteBook;
using BookReviewManager.Application.Commands.CommandsBook.UpdateBook;
using BookReviewManager.Application.Queries.BookQueries.BookQuerieById;
using BookReviewManager.Application.Queries.BookQueries.BookQuerieList;
using BookReviewManager.Domain.Entities;
using BookReviewManager.Domain.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, result);
        }

        /// <summary>
        /// Esse metodo realiza a paginação de uma lista de livros, retornando uma lista paginada
        /// </summary>
        /// <param name="paginacao">Esse parametro irá trazer a lista com o numero de livros por pagina que o usuario quiser</param>
        /// <returns>Retorna uma lista de livros</returns>
        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ParametrosPaginacao paginacao)
        {
            var query = new BookListQuery(paginacao.PageNumber, paginacao.PageSize);
            var result = await _mediator.Send(query);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new BookByIdQuery(id);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
            
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

        [HttpPut("cover")]
        public async Task<IActionResult> DownloadCover(int id , IFormFile file)
        {
            var command = new CoverBookCommand(id, file);

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
