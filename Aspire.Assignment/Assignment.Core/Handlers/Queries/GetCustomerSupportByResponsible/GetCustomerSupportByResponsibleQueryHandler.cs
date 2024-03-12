using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;
 
namespace Assignment.Core.Handlers.Queries
{
 
    public class GetCustomerSupportByResponsibleQueryHandler : IRequestHandler<GetCustomerSupportByResponsibleQuery, IEnumerable<CustomerSupportDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
 
        public GetCustomerSupportByResponsibleQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
 
        public async Task<IEnumerable<CustomerSupportDTO>> Handle(GetCustomerSupportByResponsibleQuery request, CancellationToken cancellationToken)
        {
            var customerSupport = await Task.FromResult(_repository.CustomerSupport.GetCustomerSupportByResponsible(request.Responsible));
            if (customerSupport == null)
            {
                throw new EntityNotFoundException($"No CustomerSupport found of Id: " + request.Responsible);
            }
            return customerSupport;
            //return customerSupport;
 
        }
    }
}