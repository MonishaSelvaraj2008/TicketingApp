using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.DTO;
 
namespace Assignment.Contracts.Data.Repositories
{
    public interface IUserStoryRepository : IRepository<UserStory> {
        IEnumerable<UserStoryDTO> GetUserStoryByCreatedBy(int CreatedBy);
        bool EqualUserStory(UpdateUserStoryDTO UserStory,UpdateUserStoryDTO OldUserStory);
 
        UserStoryDTO GetUserStoryById(int UserStoryId);
        public IEnumerable<UserStoryDTO> GetUserStoryByResponsible(int Responsible);
        public IEnumerable<UserStoryDTO> GetUserStory(int CreatedBy);
    }
}