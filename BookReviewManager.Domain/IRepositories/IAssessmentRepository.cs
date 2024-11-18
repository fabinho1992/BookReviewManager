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
        Task CreateAsync(Assessment assessment);
        Task<List<Assessment>> GetAllAsync(ParametrosPaginacao parametrosPaginacao);
        Task<List<Assessment>> GetOfUserAsync(int id);
        Task<Assessment> GetByIdAsync(int id);
        Task<Assessment> GetAllReport();
        Task Delete(Assessment assessment);
    }
}
