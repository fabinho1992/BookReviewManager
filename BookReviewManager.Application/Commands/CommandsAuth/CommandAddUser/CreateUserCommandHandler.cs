using BookReviewManager.Application.Dtos;
using BookReviewManager.Domain.IServices.Autentication;
using BookReviewManager.Domain.ModelsAutentication;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.CommandsAuth.CommandAddUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResultViewModel<ResponseIdentityCreate>>
    {
        public ICreateUser _createUser;

        public CreateUserCommandHandler(ICreateUser createUser)
        {
            _createUser = createUser;
        }

        public async Task<ResultViewModel<ResponseIdentityCreate>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new RegisterUser(request.UserName, request.Email, request.Password);
            var userCreate = await _createUser.CreateUserAsync(user);

            return ResultViewModel<ResponseIdentityCreate>.Success(userCreate);
            
        }
    }
}
