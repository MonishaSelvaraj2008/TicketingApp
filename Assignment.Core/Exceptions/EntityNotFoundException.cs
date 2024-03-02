namespace Assignment.Core.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message)
        {
        }
        
    }

    public class InvalidcredentialsException : Exception
    {
        public InvalidcredentialsException(string message) : base(message)
        {
        }
      
    }
    public class NotFoundException : Exception
    {
        public NotFoundException() { }

        public NotFoundException(string message) : base(message) { }

        public NotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
    
    public class NotChangedException : Exception
    {
        public string[] Errors = {"No changes to Update"};
      
    
    }
}
