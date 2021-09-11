using App.Domain.Entities;
using FluentValidation;
namespace App.Domain.Validators
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(a => a.Login)
             .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.");
        }
    }
}
