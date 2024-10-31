using BookReviewManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Domain.IRepositories
{
    public interface IBookRepository
    {
        Task CreateAsync(Book book);
        Task<List<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task Update(Book book);
        Task Delete(Book book);
    }
}
