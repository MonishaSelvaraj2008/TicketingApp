using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Contracts.DTO;
using Assignment.Migrations;

namespace Assignment.Core.Data.Repositories
{
    public class BugRepository : Repository<Bug>, IBugRepository
    {
        private readonly DatabaseContext _context;
        public BugRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<BugDTO> GetBug(int CreatedBy)
        {
            using (_context)
            {
            var query = from Bug in _context.Bug
                join User in _context.Users on Bug.Responsible equals User.Id
                join Status in _context.Status on Bug.StatusId equals Status.Id
                where Bug.CreatedBy == CreatedBy
                select new BugDTO
                {
                    Id = Bug.Id,
                    Description = Bug.Description,
                    Environment = Bug.Environment,
                    Priority = Bug.Priority,
                    Responsible = Bug.Responsible,
                    ResponsibleName = User.FirstName+" "+User.LastName,
                    Regression = Bug.Regression,
                    FixedID = Bug.FixedID,
                    NotFixedReason = Bug.NotFixedReason,
                    CreatedBy = Bug.CreatedBy,
                    StatusId = Bug.StatusId,
                    Status = Status.State,
                    Version = Bug.Version,
                    Comments = Bug.Comments
                };
 
            return query.ToList();
            }
        }

        public bool EqualBug(UpdateBugDTO Bug,UpdateBugDTO OldBug){
            bool result = false;
            if(Bug.Id==OldBug.Id && Bug.Description.Equals(OldBug.Description) &&
              Bug.Environment.Equals(OldBug.Environment) && Bug.Priority==OldBug.Priority && 
              Bug.Responsible == OldBug.Responsible && Bug.Regression==OldBug.Regression &&
              Bug.FixedID.Equals(OldBug.FixedID) && Bug.StatusId == OldBug.StatusId &&
              Bug.NotFixedReason.Equals(OldBug.NotFixedReason) && Bug.Comments.Equals(OldBug.Comments)){
                result = true;
            }
            return result;
        }
    }
}