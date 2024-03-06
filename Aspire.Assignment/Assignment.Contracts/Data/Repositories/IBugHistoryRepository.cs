using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.DTO;

namespace Assignment.Contracts.Data.Repositories
{
    public interface IBugHistoryRepository : IRepository<BugHistory> {

        IEnumerable<BugHistoryDTO> GetBugHistory(int UserStoryId);

    }
}