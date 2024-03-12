using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.DTO;

namespace Assignment.Contracts.Data.Repositories
{
    public interface ICustomerSupportRepository : IRepository<CustomerSupport>
    {
         IEnumerable<CustomerSupportDTO> GetCustomerSupportByCreatedBy(int CreatedBy);
        bool EqualCustomerSupport(UpdateCustomerSupportDTO CustomerSupport,UpdateCustomerSupportDTO OldCustomerSupport);
        CustomerSupportDTO GetCustomerSupportById(int CustomerSupportId);
        public IEnumerable<CustomerSupportDTO> GetCustomerSupportByResponsible(int Responsible);
 
    }
}
