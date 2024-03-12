using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Migrations;

namespace Assignment.Core.Data.Repositories
{
    public class CustomerDetailsRepository : Repository<CustomerDetails>, ICustomerDetailsRepository
    {
        public CustomerDetailsRepository(DatabaseContext context) : base(context)
        {
        }
    }
}