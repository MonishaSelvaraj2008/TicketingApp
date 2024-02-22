using Assignment.Contracts.Data.Repositories;

namespace Assignment.Contracts.Data
{
    public interface IUnitOfWork
    {
        IBugRepository Bug { get; }
        IBugHistoryRepository BugHistory { get; }
        IUserStoryHistoryRepository UserStoryHistory { get; }
        IUserStoryRepository UserStory {get;}
        Task CommitAsync();
    }
}