using Assignment.Contracts.Data;
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Core.Data.Repositories;
using Assignment.Migrations;

namespace Assignment.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public IBugRepository Bug => new BugRepository(_context);
        
         public IUserStoryRepository UserStory => new UserStoryRepository(_context);
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    
    }
}