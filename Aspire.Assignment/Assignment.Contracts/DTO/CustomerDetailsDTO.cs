using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Contracts.DTO
{
    public class CustomerDetailsDTO
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
       
    }
}
