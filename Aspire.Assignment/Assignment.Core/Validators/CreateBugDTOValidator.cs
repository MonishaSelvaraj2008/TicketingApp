﻿using Assignment.Contracts.DTO;
using FluentValidation;

namespace Assignment.Core.Validators
{
    public class CreateBugDTOValidator : AbstractValidator<CreateBugDTO>
    {
        public CreateBugDTOValidator()
        {
           
            RuleFor(x => x.CreatedBy).NotEmpty().NotNull().WithMessage("CreatedBy is required");
        }
    }
}
