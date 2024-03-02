using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;

namespace Assignment.Core.Handlers.Queries
{
    public class GetUserStoryByIdQuery : IRequest<IEnumerable<UserStoryDTO>>
    {
        public int UserStoryId{get; set;}
    }
}