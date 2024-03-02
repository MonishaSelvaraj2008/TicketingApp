using Assignment.Contracts.DTO;
using FluentValidation;

namespace Assignment.Core.Validators
{
    public class CreateUserStoryDTOValidator : AbstractValidator<CreateUserStoryDTO>
    {
        public CreateUserStoryDTOValidator()
        {
    
            RuleFor(x => x.Responsible).NotEmpty().NotNull().WithMessage("Responsible Field is required");
            RuleFor(x => x.StoryPoint).NotEmpty().NotNull().WithMessage("StoryPoint is required");
            RuleFor(x => x.AcceptanceCriteria).NotEmpty().NotNull().WithMessage("AcceptanceCriteria is required");
            RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage("Description is required");
            RuleFor(x => x.CreatedBy).NotEmpty().NotNull().WithMessage("CreatedBy is required");
        }
    }
}
