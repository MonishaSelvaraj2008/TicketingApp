namespace Assignment.Contracts.DTO
{
    public class CreateUsersDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Designation { get; set; }
        public string Role { get; set; }
        public string EmailID { get; set; }        
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        
    }
}