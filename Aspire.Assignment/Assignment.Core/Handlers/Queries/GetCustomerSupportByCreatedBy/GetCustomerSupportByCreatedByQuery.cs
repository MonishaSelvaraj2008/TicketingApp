using MediatR;
using Assignment.Contracts.DTO;

namespace Assignment.Core.Handlers.Queries
{
    public class GetCustomerSupportByCreatedByQuery : IRequest<IEnumerable<CustomerSupportDTO>>
    {
        public int CreatedBy{ get; set; }

    }
}