using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Migrations;

namespace Assignment.Core.Data.Repositories
{
    public class BugRepository : Repository<Bug>, IBugRepository
    {
        public BugRepository(DatabaseContext context) : base(context)
        {
        }
    }
}