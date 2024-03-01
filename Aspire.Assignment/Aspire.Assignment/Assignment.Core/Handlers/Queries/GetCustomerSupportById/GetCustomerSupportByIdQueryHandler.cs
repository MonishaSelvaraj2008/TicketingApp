using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;

namespace Assignment.Core.Handlers.Queries
{

    public class GetCustomerSupportByIdQueryHandler : IRequestHandler<GetCustomerSupportByIdQuery, CustomerSupportDTO>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetCustomerSupportByIdQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomerSupportDTO> Handle(GetCustomerSupportByIdQuery request, CancellationToken cancellationToken)
        {
            var customerSupport = await Task.FromResult(_repository.CustomerSupport.Get(request.CustomerSupportId));

            if (customerSupport == null)
            {
                throw new EntityNotFoundException($"No CustomerSupport found of Id: " + request.CustomerSupportId);
            }

            return _mapper.Map<CustomerSupportDTO>(customerSupport);
        }
    }
}