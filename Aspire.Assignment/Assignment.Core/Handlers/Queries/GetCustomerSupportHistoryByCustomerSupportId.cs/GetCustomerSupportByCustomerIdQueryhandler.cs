using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;
using Assignment.Contracts.Data.Entities;

namespace Assignment.Core.Handlers.Queries
{

    public class GetCustomerSupportHistoryByCustomerSupportIdQueryHandler : IRequestHandler<GetCustomerSupportHistoryByCustomerSupportIdQuery, IEnumerable<CustomerSupportHistoryDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetCustomerSupportHistoryByCustomerSupportIdQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerSupportHistoryDTO>> Handle(GetCustomerSupportHistoryByCustomerSupportIdQuery request, CancellationToken cancellationToken)
        {
            var customerSupportHistory = await Task.FromResult(_repository.CustomerSupportHistory.GetAll().Where(obj => obj.CustomerSupportId == request.CustomerSupportId));

            if (customerSupportHistory == null)
            {
                throw new EntityNotFoundException($"No User Story found of Id: " + request.CustomerSupportId);
            }

            List<CustomerSupportHistory> customerSupportHistories = customerSupportHistory.ToList();
            return _mapper.Map<List<CustomerSupportHistoryDTO>>(customerSupportHistory);
        }
    }
}