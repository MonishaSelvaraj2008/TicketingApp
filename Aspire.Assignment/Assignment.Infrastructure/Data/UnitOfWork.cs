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
        public IUserRepository User => new UserRepository(_context);
        public IBugRepository Bug => new BugRepository(_context);

        public IBugHistoryRepository BugHistory => new BugHistoryRepository(_context);
        public ICustomerSupportRepository CustomerSupport => new CustomerSupportRepository(_context);
        public ICustomerSupportHistoryRepository CustomerSupportHistory => new CustomerSupportHistoryRepository(_context);
        
        public IUserStoryRepository UserStory => new UserStoryRepository(_context);

        public IUserStoryHistoryRepository UserStoryHistory => new UserStoryHistoryRepository(_context);
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    
    }
}