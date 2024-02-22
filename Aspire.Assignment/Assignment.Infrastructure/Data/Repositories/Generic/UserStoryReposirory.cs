using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Migrations;

namespace Assignment.Core.Data.Repositories
{
    public class UserStoryRepository : Repository<UserStory>, IUserStoryRepository
    {
        public UserStoryRepository(DatabaseContext context) : base(context)
        {
        }
    }
}