using BookReviewManager.Application.Commands.CommandsUser.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.FluentValidation.UserValidation
{
    public class CreateUserValidation : AbstractValidator<UserCreateCommand>
    {
        public CreateUserValidation()
        {
            RuleFor(u => u.Name).NotEmpty().NotNull()
                .WithMessage("Name cannot be null")
                .MaximumLength(100).WithMessage("Must contain a maximum of 100 characters")
                .MinimumLength(3).WithMessage("Must contain a minimum of 3 characters");

            RuleFor(u => u.Email).NotEmpty().NotNull()
                .WithMessage("Email cannot be null")
                .EmailAddress().WithMessage("Insert a email valid ");
        }
    }
}
