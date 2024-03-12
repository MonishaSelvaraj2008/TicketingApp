using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;

namespace Assignment.Core.Handlers.Queries
{
    public class GetCustomerSupportHistoryByCustomerSupportIdQuery : IRequest<IEnumerable<CustomerSupportHistoryDTO>>
    {
        public int CustomerSupportId{get; set;}
    }
}