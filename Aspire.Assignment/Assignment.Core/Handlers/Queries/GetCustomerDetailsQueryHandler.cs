using AutoMapper;
using Assignment.Contracts.Data;
using Assignment.Contracts.DTO;
using MediatR;
namespace Assignment.Providers.Handlers.Queries
{
    public class GetCustomerDetailsQuery:IRequest<IEnumerable<CustomerDetailsDTO>>
    {
   
    }
    public class GetCustomerDetailsQueryHandler : IRequestHandler<GetCustomerDetailsQuery, IEnumerable<CustomerDetailsDTO>>
        {
            private readonly IUnitOfWork _repository;
            private readonly IMapper _mapper;
   
            public GetCustomerDetailsQueryHandler(IUnitOfWork repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
   
            public async Task<IEnumerable<CustomerDetailsDTO>> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
            {
                var entities = await Task.FromResult(_repository.CustomerDetails.GetAll());
                return _mapper.Map<IEnumerable<CustomerDetailsDTO>>(entities);
            }
        }
}