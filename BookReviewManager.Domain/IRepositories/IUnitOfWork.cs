using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Domain.IRepositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IBookRepository BookRepository { get; }
        IAssessmentRepository AssessmentRepository { get; }
        Task Commit();
    }
}
