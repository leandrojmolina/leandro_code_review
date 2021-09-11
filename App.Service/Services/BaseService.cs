using App.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace App.Service.Services
{
    public abstract class BaseService
    {
        private readonly INotifier _notifier;

        protected BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage, false);
            }
        }

        protected void Notify(string errorMessage, bool success)
        {
            _notifier.Handle(new Domain.Notifications.Notification(errorMessage, success));
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity, string rs = null) where TV : AbstractValidator<TE> where TE : Domain.Entities.Entity
        {
            _ = new ValidationResult();
            ValidationResult validator;
            if (string.IsNullOrEmpty(rs))
            {
                validator = validation.Validate(entity);
            }
            else
            {
                validator = validation.Validate(entity);
            }

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }
    }
}
