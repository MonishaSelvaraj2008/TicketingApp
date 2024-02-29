using Assignment.Contracts.DTO;
using FluentValidation;

namespace Assignment.Core.Validators
{
    public class CreateUserStoryDTOValidator : AbstractValidator<CreateUserStoryDTO>
    {
        public CreateUserStoryDTOValidator()
        {
    
            RuleFor(x => x.CreatedBy).NotEmpty().NotNull().WithMessage("CreatedBy is required");
        }
    }
}
