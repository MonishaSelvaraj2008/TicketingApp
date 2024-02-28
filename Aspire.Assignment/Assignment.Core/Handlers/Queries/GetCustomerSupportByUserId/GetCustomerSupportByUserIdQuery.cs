using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data.Entities;

namespace Assignment.Core.Handlers.Queries
{
    public class GetCustomerSupportByUserIdQuery : IRequest<IEnumerable<CustomerSupportDTO>>
    {
        public int CreatedBy{ get; set; }

    }
}