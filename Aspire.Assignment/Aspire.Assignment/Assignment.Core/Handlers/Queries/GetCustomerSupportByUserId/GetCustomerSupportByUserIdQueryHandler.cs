using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;
using Assignment.Contracts.Data.Entities;

namespace Assignment.Core.Handlers.Queries
{

    public class GetCustomerSupportByUserIdQueryHandler : IRequestHandler<GetCustomerSupportByUserIdQuery, IEnumerable<CustomerSupportDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetCustomerSupportByUserIdQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerSupportDTO>> Handle(GetCustomerSupportByUserIdQuery request, CancellationToken cancellationToken)
        {
            var customerSupport = await Task.FromResult(_repository.CustomerSupport.GetAll().Where(obj=>obj.CreatedBy == request.CreatedBy));
            if (customerSupport == null)
            {
                throw new EntityNotFoundException($"No Customer Support found of Id: " + request.CreatedBy);
            }
            List<CustomerSupport> customerSupports = customerSupport.ToList();
            return _mapper.Map<List<CustomerSupportDTO>>(customerSupport);
            //return customerSupport;

        }
    }
}