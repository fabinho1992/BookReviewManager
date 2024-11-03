using BookReviewManager.Domain.IRepositories;
using BookReviewManager.Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IBookRepository? _bookRepository;
        private IUserRepository? _userRepository;
        private IAssessmentRepository? _assessmentRepository;


        private readonly BookManagerContext _context;

        public UnitOfWork(BookManagerContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository = _userRepository ?? new UserRepository(_context);
            }
        }

        public IBookRepository BookRepository
        {
            get
            {
                return _bookRepository = _bookRepository ?? new BookRepository(_context);   
            }
        }

        public IAssessmentRepository AssessmentRepository
        {
            get 
            {
                return _assessmentRepository = _assessmentRepository ?? new AssessmentsRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Dispose()
        {
            await _context.DisposeAsync();
        }
    }
}
