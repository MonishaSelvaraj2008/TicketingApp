using MediatR;
using Assignment.Contracts.DTO;

namespace Assignment.Core.Handlers.Queries
{
    public class GetBugByCreatedByQuery : IRequest<IEnumerable<BugDTO>>
    {
        public int CreatedBy{ get; set; }

    }
}