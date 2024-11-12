using BookReviewManager.Application.Dtos;
using BookReviewManager.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Commands.CommandAssessment.CreateAssessment
{
    public class AssessmentCreateCommand : IRequest<ResultViewModel<int>>
    {
        public AssessmentCreateCommand(int nota, string description, int userId, int bookId)
        {
            Nota = nota;
            Description = description;
            UserId = userId;
            BookId = bookId;
        }

        public int Nota { get; private set; }
        public string Description { get; set; }
        public int UserId { get; private set; }
        public int BookId { get; private set; }
        public DateTime AssessmentDate { get; private set; } = DateTime.Now;
    }
}
