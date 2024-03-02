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
    public class UpdateCustomerSupportCommandHandler : IRequestHandler<UpdateCustomerSupportCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<UpdateCustomerSupportDTO> _validator;
        private readonly IMapper _mapper;
 
        public UpdateCustomerSupportCommandHandler(IUnitOfWork repository, IValidator<UpdateCustomerSupportDTO> validator, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }
 
        public async Task<int> Handle(UpdateCustomerSupportCommand request, CancellationToken cancellationToken)
        {
            var customerSupport = request.Model;
            var _customerSupport = await Task.FromResult(_repository.CustomerSupport.Get(customerSupport.Id));
            var oldcustomerSupport = _mapper.Map<UpdateCustomerSupportDTO>(_customerSupport);

            if(_repository.CustomerSupport.EqualCustomerSupport(customerSupport, oldcustomerSupport)){
                throw new NotChangedException();
            }
            var result = _validator.Validate(customerSupport);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }
           CustomerSupportHistory customerSupportHistory = new CustomerSupportHistory{
                CustomerSupportId = _customerSupport.Id,
                Details = _customerSupport.Details,
                CustomerId = _customerSupport.CustomerId,
                Responsible = _customerSupport.Responsible,
                StatusId = _customerSupport.StatusId,
                Comments = _customerSupport.Comments,
                Version = _customerSupport.Version
            };
            _repository.CustomerSupportHistory.Add(customerSupportHistory);
            var entity = _mapper.Map<CustomerSupport>(customerSupport);
            entity.Version=_customerSupport.Version+1;
            entity.CreatedBy=_customerSupport.CreatedBy;
            _repository.CustomerSupport.Update(entity);
            await _repository.CommitAsync();
            return entity.Id;
        }
    }
}