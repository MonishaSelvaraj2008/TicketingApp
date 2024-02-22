using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;

namespace Assignment.Core.Handlers.Queries
{
    public class GetUserStoryByIdQuery : IRequest<UserStoryDTO>
    {
        public int UserStoryId{get;}
        public GetUserStoryByIdQuery(int UserStoryId){
            this.UserStoryId = UserStoryId;
        }
    }
}