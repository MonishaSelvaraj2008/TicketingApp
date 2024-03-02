using Assignment.Contracts.DTO;
 
namespace Assignment.Contracts.Data.Repositories
{
    public interface IBugRepository : IRepository<Bug> {
        IEnumerable<BugDTO> GetBug(int CreatedBy);
        bool EqualBug(UpdateBugDTO Bug,UpdateBugDTO OldBug);
    }
}