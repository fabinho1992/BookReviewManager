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

        public async Task CreateAsync(Assessment assessment)
        {
            await _context.Assessments.AddAsync(assessment);
        }

        public async Task Delete(Assessment assessment)
        {
            var assessmentDelete = await GetByIdAsync(assessment.Id);
            _context.Assessments.Remove(assessmentDelete);
        }

        public async Task<List<Assessment>> GetAllAsync(ParametrosPaginacao paginacao)
        {
            return await _context.Assessments.Include(a => a.User).Include(a => a.Book)
                .OrderBy(a => a.Id)
                .Skip((paginacao.PageNumber - 1) * paginacao.PageSize)
                .Take(paginacao.PageSize).ToListAsync();
        }

        public async Task<Assessment> GetByIdAsync(int id)
        {
            var assessment = await _context.Assessments.Include(a => a.User)
                .Include(a => a.Book).SingleOrDefaultAsync(a => a.Id == id);

            return assessment;
        }

        public async Task<List<Assessment>> GetOfUserAsync(int id)
        {
            return await _context.Assessments
            .Where(a => a.User.Id == id)
            .ToListAsync();

            
        }
    }
}
