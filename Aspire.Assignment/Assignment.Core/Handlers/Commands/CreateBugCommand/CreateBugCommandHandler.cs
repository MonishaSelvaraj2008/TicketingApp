using MediatR;
using Assignment.Contracts.Data;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data.Entities;
using FluentValidation;
using System.Text.Json;
using Assignment.Core.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Assignment.Core.Handlers.Commands
{
    public class CreateBugCommandHandler : IRequestHandler<CreateBugCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<CreateBugDTO> _validator;

        public CreateBugCommandHandler(IUnitOfWork repository, IValidator<CreateBugDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<int> Handle(CreateBugCommand request, CancellationToken cancellationToken)
        {
            CreateBugDTO model = request.Model;

            var result = _validator.Validate(model);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }
            
            var entity = new Bug
            {
                Description = model.Description,
                Environment = model.Environment,
                Priority = model. Priority ,
                Responsible =  model.Responsible,
                Regression = model.Regression,
                FixedID = model.FixedID,
                NotFixedReason = model.NotFixedReason,
                Version = 1,
                Comments = model.Comments,
                StatusId = model.StatusId,
                CreatedBy = model.CreatedBy,
            };

            _repository.Bug.Add(entity);
            await _repository.CommitAsync();

            return entity.Id;
        }
    }
}