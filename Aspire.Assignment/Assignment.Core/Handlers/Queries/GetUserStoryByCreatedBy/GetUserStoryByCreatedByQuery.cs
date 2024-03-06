using MediatR;
using Assignment.Contracts.DTO;

namespace Assignment.Core.Handlers.Queries
{
    public class GetUserStoryByCreatedByQuery : IRequest<IEnumerable<UserStoryDTO>>
    {
        public int CreatedBy{ get; set; }
        public string? Search {get;set;}
    }
}