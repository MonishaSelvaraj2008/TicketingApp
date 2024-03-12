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
    public class CreateCustomerSupportCommandHandler : IRequestHandler<CreateCustomerSupportCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<CreateCustomerSupportDTO> _validator;

        private readonly IMapper _mapper;

        public CreateCustomerSupportCommandHandler(IUnitOfWork repository, IValidator<CreateCustomerSupportDTO> validator, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> Handle(CreateCustomerSupportCommand request, CancellationToken cancellationToken)
        {
            var customerSupport = request.Model;
            var result = _validator.Validate(customerSupport);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }
            var entity = _mapper.Map<CustomerSupport>(customerSupport);
            entity.Version=1;
            entity.StatusId=1;
            _repository.CustomerSupport.Add(entity);
            await _repository.CommitAsync();
            return entity.Id;
        }
    }
}