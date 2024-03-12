using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.DTO;

namespace Assignment.Contracts.Data.Repositories
{
    public interface IUserStoryHistoryRepository : IRepository<UserStoryHistory> 
    {
        IEnumerable<UserStoryHistoryDTO> GetUserStoryHistory(int UserStoryId);
    }
}