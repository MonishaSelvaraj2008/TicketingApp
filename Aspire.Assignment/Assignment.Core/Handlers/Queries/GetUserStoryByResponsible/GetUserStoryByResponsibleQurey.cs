using MediatR;
using Assignment.Contracts.DTO;

namespace Assignment.Core.Handlers.Queries
{
    public class GetUserStoryByResponsibleQuery : IRequest<IEnumerable<UserStoryDTO>>
    {
        public int Responsible{ get; set; }

    }
}