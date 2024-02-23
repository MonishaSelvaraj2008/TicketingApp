using Assignment.Contracts.DTO;
using FluentValidation;

namespace Assignment.Core.Validators
{
    public class CreateCustomerSupportDTOValidator : AbstractValidator<CreateCustomerSupportDTO>
    {
        public CreateCustomerSupportDTOValidator()
        {
            // RuleFor(x => x.StatusId).NotEmpty().NotNull().WithMessage("Status is required");
            RuleFor(x => x.CreatedBy).NotEmpty().NotNull().WithMessage("CreatedBy is required");
        }
    }
}
