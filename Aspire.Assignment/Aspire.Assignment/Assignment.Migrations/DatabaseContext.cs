using Microsoft.EntityFrameworkCore;
using Assignment.Contracts.Data.Entities;

namespace Assignment.Migrations
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<BaseEntity>().AsEnumerable())
            {
                item.Entity.AddedOn = DateTime.Now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserStory> UserStory { get; set; }
        public DbSet<Bug> Bug { get; set; }
        public DbSet<CustomerSupport> CustomerSupport { get; set; }
        public DbSet<CustomerDetails> CustomerDetails { get; set; }
        
        public DbSet<UserStoryHistory> UserStoryHistory { get; set; }
         public DbSet<BugHistory> BugHistory { get; set; }
        public DbSet<CustomerSupportHistory> CustomerSupportHistory{ get; set; }
        public DbSet<Status> Status {get; set;}
    }
}