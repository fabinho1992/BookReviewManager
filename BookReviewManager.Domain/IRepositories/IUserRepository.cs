using BookReviewManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Domain.IRepositories
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
        Task<List<User>> GetAllAsync(ParametrosPaginacao parametrosPaginacao);
        Task<User> GetByIdAsync(int id);
        void Update(User user);
        Task Delete(User user);
    }
}
