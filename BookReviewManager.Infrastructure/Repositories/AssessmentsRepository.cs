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
    public class AssessmentsRepository : IAssessmentRepository
    {
        private readonly BookManagerContext _context;

        public AssessmentsRepository(BookManagerContext context)
        {
            _context = context;
        }

        public async Task Create(Assessment assessment)
        {
            await _context.Assessments.AddAsync(assessment);
        }

        public Task Delete(Assessment assessment)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Assessment>> GetAllAsync(ParametrosPaginacao paginacao)
        {
            return await _context.Assessments.AsNoTracking().OrderBy(a => a.Id)
                .Skip((paginacao.PageNumber - 1) * paginacao.PageSize)
                .Take(paginacao.PageSize).ToListAsync();
        }

        public async Task<Assessment> GetByIdAsync(int id)
        {
            var assessment = await _context.Assessments.Include(a => a.User)
                .Include(a => a.Book).SingleOrDefaultAsync();

            return assessment;
        }

        public Task<Assessment> GetOfUserAsync(int id)
        {
            var assessmentUser = _context.Assessments.Include(a => a.User)
        }
    }
}
