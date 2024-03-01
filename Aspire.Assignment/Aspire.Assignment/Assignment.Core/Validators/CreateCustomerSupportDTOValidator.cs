using Assignment.Contracts.DTO;
using FluentValidation;

namespace Assignment.Core.Validators
{
    public class CreateCustomerSupportDTOValidator : AbstractValidator<CreateCustomerSupportDTO>
    {
        public CreateCustomerSupportDTOValidator()
        {
           
            RuleFor(x => x.CreatedBy).NotEmpty().NotNull().WithMessage("CreatedBy is required");
        }
    }
}
