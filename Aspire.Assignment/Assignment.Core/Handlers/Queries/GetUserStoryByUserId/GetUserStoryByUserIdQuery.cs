using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data.Entities;

namespace Assignment.Core.Handlers.Queries
{
    public class GetUserStoryByUserIdQuery : IRequest<IEnumerable<UserStoryDTO>>
    {
        public int CreatedBy{ get; set; }

    }
}