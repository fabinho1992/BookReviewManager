using BookReviewManager.Application.Commands.CommandsUser.CreateUser;
using BookReviewManager.Domain.Entities;
using BookReviewManager.Domain.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System;
using BookReviewManager.Application.Queries.UserQueries.UserQueriesById;
using BookReviewManager.Application.Queries.UserQueries.UserQuerieList;
using BookReviewManager.Application.Commands.CommandsUser.UpadateUser;
using BookReviewManager.Application.Dtos.ViewModels.UserViewsModel;
using BookReviewManager.Application.Commands.CommandsUser.DeleteUser;

namespace BookReviewManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public UserController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateCommand command)
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

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]ParametrosPaginacao parametrosPaginacao)
        {
            var query = new UserListQuery(parametrosPaginacao.PageNumber, parametrosPaginacao.PageSize);
            
            var result = await _mediator.Send(query);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
            
        }

        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new UserByIdQuery(id);

            var result = await _mediator.Send(query);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateCommand updateCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(updateCommand);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var query = new UserDeleteCommand(id);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess) 
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
