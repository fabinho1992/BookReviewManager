using BookReviewManager.Application.Commands.CommandsAuth.CommandCreateRole;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.FluentValidation.AuthValidation
{
    public class CreateRoleValidation : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleValidation()
        {
            RuleFor(r => r.RoleName).NotEmpty().NotNull()
                .WithMessage("Name cannot be null ")
                .MaximumLength(50)
                .MinimumLength(5)
                .WithMessage("The name must be between 5 and 50 characters long.");
                
        }
    }
}
