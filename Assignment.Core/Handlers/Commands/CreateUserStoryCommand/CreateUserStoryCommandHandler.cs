using MediatR;
using Assignment.Contracts.Data;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data.Entities;
using FluentValidation;
using System.Text.Json;
using Assignment.Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using AutoMapper;

namespace Assignment.Core.Handlers.Commands
{
    public class CreateUserStoryCommandHandler : IRequestHandler<CreateUserStoryCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<CreateUserStoryDTO> _validator;

        private readonly IMapper _mapper;

        public CreateUserStoryCommandHandler(IUnitOfWork repository, IValidator<CreateUserStoryDTO> validator, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> Handle(CreateUserStoryCommand request, CancellationToken cancellationToken)
        {
            var userStory = request.Model;
            var result = _validator.Validate(userStory);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }
            var entity = _mapper.Map<UserStory>(userStory);
            entity.Version=1;
            entity.StatusId=1;
            _repository.UserStory.Add(entity);
            await _repository.CommitAsync();
            return entity.Id;
        }
    }
}