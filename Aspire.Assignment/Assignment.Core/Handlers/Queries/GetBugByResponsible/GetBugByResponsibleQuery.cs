using MediatR;
using Assignment.Contracts.DTO;

namespace Assignment.Core.Handlers.Queries
{
    public class GetBugByResponsibleQuery : IRequest<IEnumerable<BugDTO>>
    {
        public int Responsible{ get; set; }

    }
}