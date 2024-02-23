using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;

namespace Assignment.Core.Handlers.Queries
{
    public class GetCustomerSupportByIdQuery : IRequest<CustomerSupportDTO>
    {
        public int CustomerSupportId{get; set;}
    }
}