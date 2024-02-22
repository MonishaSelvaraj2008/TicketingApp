using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;

namespace Assignment.Core.Handlers.Queries
{
    public class GetBugByIdQuery : IRequest<BugDTO>
    {
        public int BugId{get;}
        public GetBugByIdQuery(int BugId){
            this.BugId = BugId;
        }
    }
}