using BookReviewManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Domain.IRepositories
{
    public interface IAssessmentRepository
    {
        Task Create(Assessment assessment);
        Task<List<Assessment>> GetAllAsync();
        Task<List<Assessment>> GetOfUserAsync(int id);
        Task<Assessment> GetByIdAsync(int id);
        Task Delete(Assessment assessment);
    }
}
