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
    public class CreateBugCommandHandler : IRequestHandler<CreateBugCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<CreateBugDTO> _validator;
        private readonly IMapper _mapper;

        public CreateBugCommandHandler(IUnitOfWork repository, IValidator<CreateBugDTO> validator, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> Handle(CreateBugCommand request, CancellationToken cancellationToken)
        {
            var bug = request.Model;
            var result = _validator.Validate(bug);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }
            var entity = _mapper.Map<Bug>(bug);
            entity.Version=1;
            entity.StatusId=1;
            _repository.Bug.Add(entity);
            await _repository.CommitAsync();
            return entity.Id;
        }
    }
}