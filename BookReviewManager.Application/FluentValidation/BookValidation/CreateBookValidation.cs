using BookReviewManager.Application.Commands.CommandsBook.CreateBook;
using BookReviewManager.Domain.Enuns;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.FluentValidation.BookValidation
{
    public class CreateBookValidation : AbstractValidator<BookCreateCommand>
    {
        public CreateBookValidation()
        {
            RuleFor(b => b.Title).NotEmpty().NotNull()
                .WithMessage("Title cannot be null")
                .MaximumLength(100)
                .WithMessage("Must contain a maximum of 100 characters");

            RuleFor(b => b.Description).NotEmpty().NotNull()
                .WithMessage("description cannot be null")
                .MaximumLength(100)
                .WithMessage("Must contain a maximum of 100 characters");

            RuleFor(b => b.Author).NotEmpty().NotNull()
                .WithMessage("Author cannot be null")
                .MaximumLength(100)
                .WithMessage("Must contain a maximum of 100 characters");

            RuleFor(b => b.ISBN).NotNull().NotNull()
                .WithMessage("ISBN cannot be null")
                .MaximumLength(13)
                .WithMessage("Must contain a maximum of 13 characters");

            RuleFor(b => b.YearPublication).NotNull().NotEmpty()
                .WithMessage("YearOfPublication canot be null");

            RuleFor(b => b.Publisher).NotEmpty().NotNull()
                .WithMessage("Publisher cannot be null")
                .MaximumLength(80)
                .WithMessage("Must contain a maximum of 80 characters");

            RuleFor(b => b.GenerBook).NotNull()
                .WithMessage("GenerBook cannot be null")
                .IsInEnum();

            
        }
    }
}
