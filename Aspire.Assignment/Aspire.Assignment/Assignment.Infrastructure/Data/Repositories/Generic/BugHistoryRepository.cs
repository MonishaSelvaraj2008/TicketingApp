using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Migrations;

namespace Assignment.Core.Data.Repositories
{
    public class BugHistoryRepository : Repository<BugHistory>, IBugHistoryRepository
    {
        public BugHistoryRepository(DatabaseContext context) : base(context)
        {
        }
    }
}