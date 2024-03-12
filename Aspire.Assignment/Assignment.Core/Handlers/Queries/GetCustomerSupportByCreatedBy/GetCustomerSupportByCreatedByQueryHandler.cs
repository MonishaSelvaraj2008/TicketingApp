using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;
 
namespace Assignment.Core.Handlers.Queries
{
 
    public class GetCustomerSupportByCreatedByQueryHandler : IRequestHandler<GetCustomerSupportByCreatedByQuery, IEnumerable<CustomerSupportDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
 
        public GetCustomerSupportByCreatedByQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
 
        public async Task<IEnumerable<CustomerSupportDTO>> Handle(GetCustomerSupportByCreatedByQuery request, CancellationToken cancellationToken)
        {
            var customerSupport = await Task.FromResult(_repository.CustomerSupport.GetCustomerSupportByCreatedBy(request.CreatedBy));
            if (customerSupport == null)
            {
                throw new EntityNotFoundException($"No CustomerSupport found of Id: " + request.CreatedBy);
            }
            return customerSupport;
            //return customerSupport;
 
        }
    }
}