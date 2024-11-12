using BookReviewManager.Domain.Entities;
using BookReviewManager.Domain.IRepositories;
using BookReviewManager.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BookManagerContext _context;

        public UserRepository(BookManagerContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task Delete(User user)
        {
            var userDelete = await GetByIdAsync(user.Id);
            _context.Users.Remove(userDelete);
        }

        public async Task<List<User>> GetAllAsync(ParametrosPaginacao paginacao)
        {
            return await _context.Users.AsNoTracking().OrderBy(a => a.Id)
                .Skip((paginacao.PageNumber - 1) * paginacao.PageSize)
                .Take(paginacao.PageSize).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.Users.Include(u => u.Assessments).ThenInclude(u => u.Book)
                .SingleOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}
