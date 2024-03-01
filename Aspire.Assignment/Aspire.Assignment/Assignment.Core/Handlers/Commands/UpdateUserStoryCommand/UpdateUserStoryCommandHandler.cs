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
    public class UpdateUserStoryCommandHandler : IRequestHandler<UpdateUserStoryCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<UpdateUserStoryDTO> _validator;
        private readonly IMapper _mapper;
 
        public UpdateUserStoryCommandHandler(IUnitOfWork repository, IValidator<UpdateUserStoryDTO> validator, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }
 
        public async Task<int> Handle(UpdateUserStoryCommand request, CancellationToken cancellationToken)
        {
            var userStory = request.Model;
            var _userStory = await Task.FromResult(_repository.UserStory.Get(userStory.Id));
            var olduserStory = _mapper.Map<UpdateUserStoryDTO>(_userStory);
            if(userStory.Equals(olduserStory)){
                throw new NotChangedException("No Changes is made to update");
            }
            var result = _validator.Validate(userStory);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }
            UserStoryHistory userStoryHistory = new UserStoryHistory{
                UserStoryId = _userStory.Id,
                AcceptanceCriteria  = _userStory.AcceptanceCriteria,
                Description = _userStory.Description,
                StoryPoint = _userStory.StoryPoint,
                Responsible = _userStory.Responsible,
                StatusId = _userStory.StatusId,
                Comments = _userStory.Comments,
                Version = _userStory.Version
            };
            _repository.UserStoryHistory.Add(userStoryHistory);
            var entity = _mapper.Map<UserStory>(userStory);
            entity.Version=_userStory.Version+1;
            entity.CreatedBy=_userStory.CreatedBy;
            _repository.UserStory.Update(entity);
            await _repository.CommitAsync();
            return entity.Id;
        }
    }
}