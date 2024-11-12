using BookReviewManager.Application.Commands.CommandAssessment.CreateAssessment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.FluentValidation.AssessmentValidation
{
    public class CreateAssessmentValidation : AbstractValidator<AssessmentCreateCommand>
    {
        public CreateAssessmentValidation()
        {
            RuleFor(a => a.Nota).NotEmpty().NotNull()
                .WithMessage("Nota cannot be null")
                .Must(nota => nota >= 1 && nota <= 5)
                .WithMessage("Grade must be between 1 and 5");

            RuleFor(a => a.Description).NotNull().NotEmpty()
                .WithMessage("Description cannot be null")
                .MaximumLength(200)
                .WithMessage("Must contain a maximum of 200 characters");

            RuleFor(a => a.UserId).NotNull().NotEmpty()
                .WithMessage("UserId cannot be null")
                .GreaterThan(0)
                .WithMessage("Id must be greater than 0");

            RuleFor(a => a.BookId).NotNull().NotEmpty()
                .WithMessage("UserId cannot be null")
                .GreaterThan(0)
                .WithMessage("Id must be greater than 0");
        }
    }
}
