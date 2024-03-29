namespace Assignment.Contracts.DTO
{

public class UpdateBugDTO
{   
    public int Id { get; set; }
    public string Description{ get; set; }
    public string Environment{ get; set; }
    public int Priority{ get; set; }
    public int Responsible{ get; set; }
    public bool Regression{ get; set; }
    public string FixedID{ get; set; }
    public int StatusId { get; set; }
    public string NotFixedReason{ get; set; }
    public string Comments { get; set; }
    
}
}