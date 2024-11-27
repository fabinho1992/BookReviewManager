using BookReviewManager.Domain.IServices.Autentication;
using BookReviewManager.Domain.ModelsAutentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Infrastructure.Service.Identity
{
    public class CreateRole : ICreateRole
    {
        public Task<ResponseIdentityCreate> CreateRoleAsync(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
