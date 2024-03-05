using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.DTO;
 
namespace Assignment.Contracts.Data.Repositories
{
    public interface IUserStoryRepository : IRepository<UserStory> {
        IEnumerable<UserStoryDTO> GetUserStory(int CreatedBy);
        bool EqualUserStory(UpdateUserStoryDTO UserStory,UpdateUserStoryDTO OldUserStory);
 
        UserStoryDTO GetUserStoryById(int UserStoryId);
 
    }
}