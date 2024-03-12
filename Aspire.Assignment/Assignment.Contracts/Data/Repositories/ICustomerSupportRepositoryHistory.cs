using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.DTO;

namespace Assignment.Contracts.Data.Repositories
{
    public interface ICustomerSupportHistoryRepository : IRepository<CustomerSupportHistory> { 
         IEnumerable<CustomerSupportHistoryDTO> GetCustomerSupportHistory(int CustomerSupportId);
    }
}