using Assignment.Contracts.Data.Repositories;

namespace Assignment.Contracts.Data
{
    public interface IUnitOfWork
    {
        IUserRepository User {get;}
        IBugRepository Bug { get; }
        IBugHistoryRepository BugHistory { get; }
        ICustomerSupportRepository CustomerSupport { get; }
        ICustomerSupportHistoryRepository CustomerSupportHistory { get; }
        IUserStoryHistoryRepository UserStoryHistory { get; }
        IUserStoryRepository UserStory {get;}
        IStatusRepository Status {get;}
        Task CommitAsync();
    }
}