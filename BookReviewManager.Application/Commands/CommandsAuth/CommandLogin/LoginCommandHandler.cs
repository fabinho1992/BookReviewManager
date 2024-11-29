using BookReviewManager.Application.Dtos;
using BookReviewManager.Domain.IServices.Autentication;
using BookReviewManager.Domain.ModelsAutentication;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.CommandsAuth.CommandLogin
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ResultViewModel<ResponseLogin>>
    {
        private readonly ILoginUser _loginUser;

        public LoginCommandHandler(ILoginUser loginUser)
        {
            _loginUser = loginUser;
        }

        public async Task<ResultViewModel<ResponseLogin>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var login = new Login(request.Email, request.Password);
            var result = await _loginUser.LoginAsync(login);

            return new ResultViewModel<ResponseLogin>(result);
        }
    }
}
