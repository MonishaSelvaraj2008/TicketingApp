using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Contracts.DTO
{
    public class CustomerSupportDTO
    {
        public int Id { get; set; }
        public string Responsible { get; set; }
        public int CustomerId { get; set; }
        public string Details { get; set; }
        public int Version { get; set; }
        public int CreatedBy { get; set; }
        public string Comments { get; set; }
        public int StatusId { get; set; }

    }
}


