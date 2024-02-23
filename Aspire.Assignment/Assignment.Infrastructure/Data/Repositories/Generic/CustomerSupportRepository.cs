using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Migrations;

namespace Assignment.Core.Data.Repositories
{
    public class CustomerSupportRepository : Repository<CustomerSupport>, ICustomerSupportRepository
    {
        public CustomerSupportRepository(DatabaseContext context) : base(context)
        {
        }
    }
}