using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Contracts.DTO;
using Assignment.Migrations;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Core.Data.Repositories
{
    public class UserStoryRepository : Repository<UserStory>, IUserStoryRepository
    {
        private readonly DatabaseContext _context;
        public UserStoryRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<UserStoryDTO> GetUserStoryByCreatedBy(int CreatedBy)
        {
            using (_context)
            {
            var query = from UserStory in _context.UserStory
                join User in _context.Users on UserStory.Responsible equals User.Id
                join Status in _context.Status on UserStory.StatusId equals Status.Id
                where UserStory.CreatedBy == CreatedBy
                select new UserStoryDTO
                {
                    Id = UserStory.Id,
                    Description = UserStory.Description,
                    AcceptanceCriteria = UserStory.AcceptanceCriteria,
                    StoryPoint = UserStory.StoryPoint,
                    Responsible = UserStory.Responsible,
                    ResponsibleName = User.FirstName+" "+User.LastName,
                    CreatedBy = UserStory.CreatedBy,
                    StatusId = UserStory.StatusId,
                    Status = Status.State,
                    Version = UserStory.Version,
                    Comments = UserStory.Comments,
                    AddedOn = UserStory.AddedOn
                };
 
            return query.ToList();
            }
        }
 
        public bool EqualUserStory(UpdateUserStoryDTO UserStory,UpdateUserStoryDTO OldUserStory){
            bool result = false;
            if(UserStory.Id==OldUserStory.Id && UserStory.Description.Equals(OldUserStory.Description) &&
              UserStory.AcceptanceCriteria.Equals(OldUserStory.AcceptanceCriteria) && UserStory.StoryPoint==OldUserStory.StoryPoint&&
              UserStory.Responsible == OldUserStory.Responsible && UserStory.StatusId == OldUserStory.StatusId && UserStory.Comments.Equals(OldUserStory.Comments)){
                result = true;
            }
            return result;
        }
 
        public UserStoryDTO GetUserStoryById(int UserStoryId)
        {
            using (_context)
            {
            var query = from UserStory in _context.UserStory
                join User in _context.Users on UserStory.Responsible equals User.Id
                join Status in _context.Status on UserStory.StatusId equals Status.Id
                where UserStory.Id == UserStoryId
                select new UserStoryDTO
                {
                    Id = UserStory.Id,
                    Description = UserStory.Description,
                    AcceptanceCriteria = UserStory.AcceptanceCriteria,
                    StoryPoint = UserStory.StoryPoint,
                    Responsible = UserStory.Responsible,
                    ResponsibleName = User.FirstName+" "+User.LastName,
                    CreatedBy = UserStory.CreatedBy,
                    //CreatedByName = User.FirstName+" "+User.LastName,
                    StatusId = UserStory.StatusId,
                    Status = Status.State,
                    Version = UserStory.Version,
                    Comments = UserStory.Comments,
                    AddedOn = UserStory.AddedOn
                };
 
            return query.FirstOrDefault();
            }
        }
        public IEnumerable<UserStoryDTO> GetUserStoryByResponsible(int Responsible)
        {
            using (_context)
            {
            var query = from UserStory in _context.UserStory
                join User in _context.Users on UserStory.CreatedBy equals User.Id
                join Status in _context.Status on UserStory.StatusId equals Status.Id
                where UserStory.Responsible == Responsible
                select new UserStoryDTO
                {
                    Id = UserStory.Id,
                    Description = UserStory.Description,
                    AcceptanceCriteria = UserStory.AcceptanceCriteria,
                    StoryPoint = UserStory.StoryPoint,
                    Responsible = UserStory.Responsible,
                    //ResponsibleName = User.FirstName+" "+User.LastName,
                    CreatedBy = UserStory.CreatedBy,
                    CreatedByName = User.FirstName+" "+User.LastName,
                    StatusId = UserStory.StatusId,
                    Status = Status.State,
                    Version = UserStory.Version,
                    Comments = UserStory.Comments,
                    AddedOn = UserStory.AddedOn
                };
 
            return query.ToList();
            }
        }

        public IEnumerable<UserStoryDTO> GetUserStory(int CreatedBy)
        {
            using (_context)
            {
            var query = from UserStory in _context.UserStory
                join User in _context.Users on UserStory.Responsible equals User.Id
                join Status in _context.Status on UserStory.StatusId equals Status.Id
                where UserStory.CreatedBy == CreatedBy
                select new UserStoryDTO
                {
                    Id = UserStory.Id,
                    Description = UserStory.Description,
                    AcceptanceCriteria = UserStory.AcceptanceCriteria,
                    StoryPoint = UserStory.StoryPoint,
                    Responsible = UserStory.Responsible,
                    ResponsibleName = User.FirstName+" "+User.LastName,
                    CreatedBy = UserStory.CreatedBy,
                    StatusId = UserStory.StatusId,
                    Status = Status.State,
                    Version = UserStory.Version,
                    Comments = UserStory.Comments
                };
 
            return query.ToList();
            }
        }
        
    }
}