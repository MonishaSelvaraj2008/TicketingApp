using Assignment.Contracts.DTO;
using FluentValidation;
 
namespace Assignment.Core.Validators
{
    public class CreateuserDTOValidator : AbstractValidator<CreateUsersDTO>
    {
        public CreateuserDTOValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Provide passsword");
        }
    }
}
 