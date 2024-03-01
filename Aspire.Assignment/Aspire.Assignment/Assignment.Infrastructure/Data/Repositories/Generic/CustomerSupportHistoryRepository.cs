using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Migrations;

namespace Assignment.Core.Data.Repositories
{
    public class CustomerSupportHistoryRepository : Repository<CustomerSupportHistory>, ICustomerSupportHistoryRepository
    {
        public CustomerSupportHistoryRepository(DatabaseContext context) : base(context)
        {
        }
    }
}