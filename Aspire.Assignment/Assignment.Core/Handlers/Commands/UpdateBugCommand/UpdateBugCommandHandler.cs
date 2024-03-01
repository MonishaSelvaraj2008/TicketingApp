using MediatR;
using Assignment.Contracts.Data;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data.Entities;
using FluentValidation;
using System.Text.Json;
using Assignment.Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using FluentValidation.Internal;

namespace Assignment.Core.Handlers.Commands
{
    public class UpdateBugCommandHandler : IRequestHandler<UpdateBugCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<UpdateBugDTO> _validator;
        private readonly IMapper _mapper;
 
        public UpdateBugCommandHandler(IUnitOfWork repository, IValidator<UpdateBugDTO> validator, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }
 
        public async Task<int> Handle(UpdateBugCommand request, CancellationToken cancellationToken)
        {
            var bug = request.Model;
            var _bug = await Task.FromResult(_repository.Bug.Get(bug.Id));
            var oldbug = _mapper.Map<UpdateBugDTO>(_bug);

            if(_repository.Bug.EqualBug(bug, oldbug)){
                throw new NotChangedException();
            }
            var result = _validator.Validate(bug);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }
           BugHistory bugHistory = new BugHistory{
                BugId = _bug.Id,
                Description = _bug.Description,
                Environment = _bug.Environment,
                Priority = _bug.Priority,
                Responsible = _bug.Responsible,
                Regression = _bug.Regression,
                FixedID = _bug.FixedID,
                NotFixedReason = _bug.NotFixedReason,
                StatusId = _bug.StatusId,
                Comments = _bug.Comments,
                Version = _bug.Version
            };
            _repository.BugHistory.Add(bugHistory);
            var entity = _mapper.Map<Bug>(bug);
            entity.Version=_bug.Version+1;
            entity.CreatedBy=_bug.CreatedBy;
            _repository.Bug.Update(entity);
            await _repository.CommitAsync();
            return entity.Id;
        }
    }
}