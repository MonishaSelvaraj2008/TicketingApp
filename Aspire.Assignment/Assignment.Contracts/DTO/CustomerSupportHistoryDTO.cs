using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Contracts.DTO
{
    public class CustomerSupportHistoryDTO
    {
        public int Id { get; set; }
        public int CustomerSupportId {get;set;}
        public string CustomerName { get; set; }
        public int Responsible { get; set; }
        public string ResponsibleName { get; set; }
        public int CustomerId { get; set; }
        public string Details { get; set; }
        public int Version { get; set; }
        public int CreatedBy { get; set; }
        public string Comments { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }

    }
}


