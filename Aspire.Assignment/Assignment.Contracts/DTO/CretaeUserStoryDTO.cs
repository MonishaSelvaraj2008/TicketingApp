namespace Assignment.Contracts.DTO
{

public class CreateUserStoryDTO
{   

    public int StatusId{get;set;}

    public int Responsible{ get; set;}
    public int StoryPoint { get; set; }

    public string AcceptanceCriteria { get; set; }

    public string Description { get; set; }

    public string Comments { get; set; }
    public int CreatedBy {get;set;}
       
}
}
