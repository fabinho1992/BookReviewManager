using BookReviewManager.Domain.IServices.Autentication;
using BookReviewManager.Domain.ModelsAutentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Infrastructure.Service.Identity
{
    public class LoginUser : ILoginUser
    {
        public Task<ResponseLogin> LoginAsync(Login login)
        {
            throw new NotImplementedException();
        }
    }
}
