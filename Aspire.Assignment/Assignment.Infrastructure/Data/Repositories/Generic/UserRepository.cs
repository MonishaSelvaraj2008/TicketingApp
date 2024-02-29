using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Core.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }

        // public async Task<User> GetNameByUserId(int id)
        // {
        //     return await _context.UserStory
        //     .Include(responsible => responsible.Responsible)
        //     .Include(responsible => responsible.User.FirstName)
        //     .Include(responsible => responsible.User.LastName)
        //     .FirstOrDefaultAsync(userid => userid.User.Id == id);
        // }
    }
}