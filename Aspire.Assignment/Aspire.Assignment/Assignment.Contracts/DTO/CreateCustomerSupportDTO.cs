namespace Assignment.Contracts.DTO
{
    public class CreateCustomerSupportDTO
    {
        public int Responsible { get; set; }
        public int CustomerId { get; set; }
        public string Details { get; set; }
        public int CreatedBy { get; set; }
        public string Comments { get; set; }

    }
}


