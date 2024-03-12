using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Contracts.DTO;
using Assignment.Migrations;
 
namespace Assignment.Core.Data.Repositories
{
    public class CustomerSupportHistoryRepository : Repository<CustomerSupportHistory>, ICustomerSupportHistoryRepository
    {
        private readonly DatabaseContext _context;
        public CustomerSupportHistoryRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<CustomerSupportHistoryDTO> GetCustomerSupportHistory(int CustomerSupportId)
        {
            using (_context)
            {
            var query = from CustomerSupportHistory in _context.CustomerSupportHistory
                join User in _context.Users on CustomerSupportHistory.Responsible equals User.Id
                join Status in _context.Status on CustomerSupportHistory.StatusId equals Status.Id
                join CustomerDetails in _context.CustomerDetails on CustomerSupportHistory.CustomerId equals CustomerDetails.Id
                where CustomerSupportHistory.CustomerSupportId == CustomerSupportId
                select new CustomerSupportHistoryDTO
                {
                    Id = CustomerSupportHistory.Id,
                    Details = CustomerSupportHistory.Details,
                    CustomerId=CustomerSupportHistory.CustomerId,
                    CustomerName = CustomerDetails.CustomerName,
                    Responsible = CustomerSupportHistory.Responsible,
                    ResponsibleName = User.FirstName + " " + User.LastName,
                    StatusId = CustomerSupportHistory.StatusId,
                    Status = Status.State,
                    Version = CustomerSupportHistory.Version,
                    Comments = CustomerSupportHistory.Comments
                };
            return query.ToList();
            }
        }
    }
}