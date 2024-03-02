using Assignment.Contracts.DTO;
using FluentValidation;

namespace Assignment.Core.Validators
{
    public class StatusDTOValidator : AbstractValidator<StatusDTO>
    {
        public StatusDTOValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("CreatedBy is required");
        }
    }
}
