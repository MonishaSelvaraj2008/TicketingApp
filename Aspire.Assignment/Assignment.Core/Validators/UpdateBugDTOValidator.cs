using Assignment.Contracts.DTO;
using FluentValidation;

namespace Assignment.Core.Validators
{
    public class UpdateBugDTOValidator : AbstractValidator<UpdateBugDTO>
    {
        public UpdateBugDTOValidator()
        {
            RuleFor(x => x.StatusId).NotEmpty().NotNull().WithMessage("Status is required");
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Id is required");
        }
    }
}
