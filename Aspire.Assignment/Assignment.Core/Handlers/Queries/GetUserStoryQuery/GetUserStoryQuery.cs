using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;


namespace Assignment.Core.Handlers.Queries
{
    public class GetUserStoryByUserIdQuery : IRequest<UserStoryDTO>
    {
        public int CreatedBy{get;}
        public GetUserStoryByUserIdQuery(int UserId){
        CreatedBy = UserId;
        }
    }
}