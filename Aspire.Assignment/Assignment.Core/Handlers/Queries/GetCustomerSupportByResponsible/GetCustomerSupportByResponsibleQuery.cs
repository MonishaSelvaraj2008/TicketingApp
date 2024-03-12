using MediatR;
using Assignment.Contracts.DTO;

namespace Assignment.Core.Handlers.Queries
{
    public class GetCustomerSupportByResponsibleQuery : IRequest<IEnumerable<CustomerSupportDTO>>
    {
        public int Responsible{ get; set; }

    }
}