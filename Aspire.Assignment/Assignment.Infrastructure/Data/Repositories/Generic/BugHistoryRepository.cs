using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Migrations;
using Assignment.Contracts.DTO;

namespace Assignment.Core.Data.Repositories
{
    public class BugHistoryRepository : Repository<BugHistory>, IBugHistoryRepository
    {
 private readonly DatabaseContext _context;
        public BugHistoryRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<BugHistoryDTO> GetBugHistory(int BugId)
        {
            using (_context)
            {
                var query = from BugHistory in _context.BugHistory
                join User in _context.Users on BugHistory.Responsible equals User.Id 
                join Status in _context.Status on BugHistory.StatusId equals Status.Id
                where BugHistory.BugId == BugId
                select new BugHistoryDTO
                {
                   Id = BugHistory.Id,
                    Description = BugHistory.Description,
                    Environment = BugHistory.Environment,
                    Priority = BugHistory.Priority,
                    Responsible = BugHistory.Responsible,
                    ResponsibleName = User.FirstName+User.LastName,
                    Regression = BugHistory.Regression,
                    FixedID = BugHistory.FixedID,
                    NotFixedReason = BugHistory.NotFixedReason,
                    StatusId = BugHistory.StatusId,
                    Status = Status.State,
                    Version = BugHistory.Version,
                    Comments = BugHistory.Comments
                };
 
            return query.ToList();
            }
        }
    }
}