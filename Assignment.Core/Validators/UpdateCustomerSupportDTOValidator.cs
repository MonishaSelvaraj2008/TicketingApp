using Assignment.Contracts.DTO;
using FluentValidation;

namespace Assignment.Core.Validators
{
    public class UpdateCustomerSupportDTOValidator : AbstractValidator<UpdateCustomerSupportDTO>
    {
        public UpdateCustomerSupportDTOValidator()
        {
            RuleFor(x => x.StatusId).NotEmpty().NotNull().WithMessage("Status is required");
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Id is required");
        }
    }
}
