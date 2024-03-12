using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Contracts.DTO;
using Assignment.Migrations;
 
namespace Assignment.Core.Data.Repositories
{
    public class UserStoryHistoryRepository : Repository<UserStoryHistory>, IUserStoryHistoryRepository
    {
        private readonly DatabaseContext _context;
        public UserStoryHistoryRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<UserStoryHistoryDTO> GetUserStoryHistory(int UserStoryId)
        {
            using (_context)
            {
            var query = from UserStoryHistory in _context.UserStoryHistory
                join User in _context.Users on UserStoryHistory.Responsible equals User.Id
                join Status in _context.Status on UserStoryHistory.StatusId equals Status.Id
                where UserStoryHistory.UserStoryId == UserStoryId
                select new UserStoryHistoryDTO
                {
                    Id = UserStoryHistory.Id,
                    Description = UserStoryHistory.Description,
                    AcceptanceCriteria = UserStoryHistory.AcceptanceCriteria,
                    StoryPoint = UserStoryHistory.StoryPoint,
                    Responsible = UserStoryHistory.Responsible,
                    ResponsibleName = User.FirstName + " " + User.LastName,
                    StatusId = UserStoryHistory.StatusId,
                    Status = Status.State,
                    Version = UserStoryHistory.Version,
                    Comments = UserStoryHistory.Comments
                };
 
            return query.ToList();
            }
        }
    }
}