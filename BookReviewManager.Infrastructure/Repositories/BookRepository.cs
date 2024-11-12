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
    public class BookRepository : IBookRepository
    {
        private readonly BookManagerContext _context;

        public BookRepository(BookManagerContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Book book)
        {
            await _context.Books.AddAsync(book);
        }

        public async Task Delete(Book book)
        {
            var bookDelete = await GetByIdAsync(book.Id);
            _context.Books.Remove(bookDelete);  
        }

        public async Task<List<Book>> GetAllAsync(ParametrosPaginacao paginacao)
        {
            return await _context.Books.AsNoTracking().OrderBy(a => a.Id)
                .Skip((paginacao.PageNumber - 1) * paginacao.PageSize)
                .Take(paginacao.PageSize).ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var book = await _context.Books.Include(b => b.Assessments).ThenInclude(b => b.User)
                .SingleOrDefaultAsync(b => b.Id == id);

            return book;
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
        }
    }
}
