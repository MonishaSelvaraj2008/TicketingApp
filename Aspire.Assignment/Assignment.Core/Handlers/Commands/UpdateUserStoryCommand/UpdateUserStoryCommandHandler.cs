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
    public class UpdateUserStoryCommandHandler : IRequestHandler<UpdateUserStoryCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<UpdateUserStoryDTO> _validator;

        public UpdateUserStoryCommandHandler(IUnitOfWork repository, IValidator<UpdateUserStoryDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<int> Handle(UpdateUserStoryCommand request, CancellationToken cancellationToken)
        {
            UpdateUserStoryDTO model = request.Model;

            var result = _validator.Validate(model);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }
            
            var entity = new UserStory
            {
                Id = model.Id,
                Description = model.Description,
                AcceptanceCriteria = model. AcceptanceCriteria,
                StoryPoint = model.StoryPoint,
                Version = 1,
                Comments = model.Comments,
                Responsible = model.Responsible,
                StatusId=model.StatusId,
                CreatedBy=model.CreatedBy
            };


            _repository.UserStory.Update(entity);
            await _repository.CommitAsync();

            return entity.Id;
        }
    }
}