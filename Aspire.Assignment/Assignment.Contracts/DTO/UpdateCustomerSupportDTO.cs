namespace Assignment.Contracts.DTO
{

public class UpdateCustomerSupportDTO
{   
        public int Id { get; set; }
        public int Responsible { get; set; }
        public int CustomerId { get; set; }
        public string Details { get; set; }
        public string Comments { get; set; }
        public int StatusId { get; set; }
        public int CreatedBy {get;set;}
    
}
}