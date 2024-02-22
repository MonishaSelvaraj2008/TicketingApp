using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assignment.Contracts.Data.Entities;
namespace Assignment.Contracts.Data.Entities
{
public class UserStoryHistory : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } 

    [Column(TypeName = "int")]
    [ForeignKey("UserStory")]
    public int UserStoryId {get;set;}

    [Column(TypeName = "varchar(50)" )]
     public string Responsible { get; set;}    

    [Required]
    [Column(TypeName = "int")]
    public int StoryPoint { get; set; }

    [Column(TypeName = "varchar(250)")]
    public string AcceptanceCriteria { get; set; }

    [Column(TypeName = "varchar(250)")]
    public string Description { get; set; }

    [Column(TypeName = "int")]
    public int StatusId { get; set; }

    [Column(TypeName = "int")]
    public int Version { get; set; }

    [Column(TypeName = "varchar(250)")]
    public string Comments { get; set; }


    public UserStory UserStory { get; set; }


}
}