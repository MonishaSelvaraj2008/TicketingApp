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
        public IEnumerable<CustomerSupportDTO> GetCustomerSupportByCreatedBy(int CreatedBy)
        {
            using (_context)
            {
            var query = from CustomerSupport in _context.CustomerSupport
                join User in _context.Users on CustomerSupport.Responsible equals User.Id
                join Status in _context.Status on CustomerSupport.StatusId equals Status.Id
                join CustomerDetails in _context.CustomerDetails on CustomerSupport.CustomerId equals CustomerDetails.Id
                where CustomerSupport.CreatedBy == CreatedBy
                select new CustomerSupportDTO
                {
                    Id = CustomerSupport.Id,
                    Details = CustomerSupport.Details,
                    CustomerId = CustomerSupport.CustomerId,
                    CustomerName = CustomerDetails.CustomerName,
                    Responsible = CustomerSupport.Responsible,
                    ResponsibleName = User.FirstName+" "+User.LastName,
                    CreatedBy = CustomerSupport.CreatedBy,
                    StatusId = CustomerSupport.StatusId,
                    Status = Status.State,
                    Version = CustomerSupport.Version,
                    Comments = CustomerSupport.Comments,
                    AddedOn = CustomerSupport.AddedOn
                };
 
            return query.ToList();
            }
        }

        public bool EqualCustomerSupport(UpdateCustomerSupportDTO CustomerSupport,UpdateCustomerSupportDTO OldCustomerSupport){
            bool result = false;
            if(CustomerSupport.Id==OldCustomerSupport.Id && CustomerSupport.Details.Equals(OldCustomerSupport.Details) && CustomerSupport.CustomerId.Equals(OldCustomerSupport.CustomerId) &&
              CustomerSupport.Responsible == OldCustomerSupport.Responsible && CustomerSupport.StatusId == OldCustomerSupport.StatusId &&
             CustomerSupport.Comments.Equals(OldCustomerSupport.Comments)){
              result = true;
            }
            return result;
        }

        public CustomerSupportDTO GetCustomerSupportById(int CustomerSupportId)
        {
            using (_context)
            {
            var query = from CustomerSupport in _context.CustomerSupport
                join User in _context.Users on CustomerSupport.Responsible equals User.Id
                join Status in _context.Status on CustomerSupport.StatusId equals Status.Id
                join CustomerDetails in _context.CustomerDetails on CustomerSupport.CustomerId equals CustomerDetails.Id
                where CustomerSupport.Id == CustomerSupportId
                select new CustomerSupportDTO
                {
                   Id = CustomerSupport.Id,
                    Details = CustomerSupport.Details,
                    CustomerId=CustomerSupport.CustomerId,
                    CustomerName = CustomerDetails.CustomerName,
                    Responsible = CustomerSupport.Responsible,
                    ResponsibleName = User.FirstName+User.LastName,
                    CreatedBy = CustomerSupport.CreatedBy,
                    StatusId = CustomerSupport.StatusId,
                    Status = Status.State,
                    Version = CustomerSupport.Version,
                    Comments = CustomerSupport.Comments,
                    AddedOn = CustomerSupport.AddedOn
                };
 
            return query.FirstOrDefault();
            }
        }
        public IEnumerable<CustomerSupportDTO> GetCustomerSupportByResponsible(int Responsible)
        {
            using (_context)
            {
            var query = from CustomerSupport in _context.CustomerSupport
                join User in _context.Users on CustomerSupport.CreatedBy equals User.Id
                join Status in _context.Status on CustomerSupport.StatusId equals Status.Id
                join CustomerDetails in _context.CustomerDetails on CustomerSupport.CustomerId equals CustomerDetails.Id
                
                where CustomerSupport.Responsible == Responsible
                select new CustomerSupportDTO
                {
                    Id = CustomerSupport.Id,
                    Details = CustomerSupport.Details,
                    CustomerId=CustomerSupport.CustomerId,
                    CustomerName = CustomerDetails.CustomerName,
                    Responsible = CustomerSupport.Responsible,
                    CreatedBy = CustomerSupport.CreatedBy,
                    CreatedByName = User.FirstName+" "+User.LastName,
                    StatusId = CustomerSupport.StatusId,
                    Status = Status.State,
                    Version = CustomerSupport.Version,
                    Comments = CustomerSupport.Comments,
                    AddedOn = CustomerSupport.AddedOn
                };
 
            return query.ToList();
            }
        }

    }
}