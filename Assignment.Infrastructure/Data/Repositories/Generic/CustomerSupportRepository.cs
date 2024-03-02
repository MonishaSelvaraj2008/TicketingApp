using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Contracts.DTO;
using Assignment.Migrations;

namespace Assignment.Core.Data.Repositories
{
    public class CustomerSupportRepository : Repository<CustomerSupport>, ICustomerSupportRepository
    {
        private readonly DatabaseContext _context;
        public CustomerSupportRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<CustomerSupportDTO> GetCustomerSupport(int CreatedBy)
        {
            using (_context)
            {
            var query = from CustomerSupport in _context.CustomerSupport
                join User in _context.Users on CustomerSupport.Responsible equals User.Id
                join Status in _context.Status on CustomerSupport.StatusId equals Status.Id
                where CustomerSupport.CreatedBy == CreatedBy
                select new CustomerSupportDTO
                {
                    Id = CustomerSupport.Id,
                    Details = CustomerSupport.Details,
                    CustomerId=CustomerSupport.CustomerId,
                    Responsible = CustomerSupport.Responsible,
                    ResponsibleName = User.FirstName+" "+User.LastName,
                    CreatedBy = CustomerSupport.CreatedBy,
                    StatusId = CustomerSupport.StatusId,
                    Status = Status.State,
                    Version = CustomerSupport.Version,
                    Comments = CustomerSupport.Comments
                };
 
            return query.ToList();
            }
        }

        public bool EqualCustomerSupport(UpdateCustomerSupportDTO CustomerSupport,UpdateCustomerSupportDTO OldCustomerSupport){
            bool result = false;
            if(CustomerSupport.Id==OldCustomerSupport.Id && CustomerSupport.Details.Equals(OldCustomerSupport.Details) &&
              CustomerSupport.CustomerId.Equals(OldCustomerSupport.CustomerId)  && 
              CustomerSupport.Responsible == OldCustomerSupport.Responsible && CustomerSupport.StatusId == OldCustomerSupport.StatusId
               && CustomerSupport.Comments.Equals(OldCustomerSupport.Comments)){
                result = true;
            }
            return result;
        }
    }
}