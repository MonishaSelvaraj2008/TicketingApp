using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Migrations;

namespace Assignment.Core.Data.Repositories
{
    public class UserStoryHistoryRepository : Repository<UserStoryHistory>, IUserStoryHistoryRepository
    {
        public UserStoryHistoryRepository(DatabaseContext context) : base(context)
        {
        }
    }
}