
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assignment.Contracts.Data.Entities;
namespace Assignment.Contracts.Data.Entities
{
public class BugHistory : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column(TypeName = "int")]
    
    [ForeignKey("Bug")]
    public int BugId { get; set; }
 
    [Column(TypeName = "varchar(250)")]
    public string Description{ get; set; }
 
    [Column(TypeName = "varchar(50)")]
    public string Environment{ get; set; }
 
    [Column(TypeName = "int")]
    public int Priority{ get; set; }
   
    [Column(TypeName = "int")]
    public int Responsible{ get; set; }
 
    public bool Regression{ get; set; }
 
    [Column(TypeName = "varchar(50)")]
    public string FixedID{ get; set; }
 
    [Column(TypeName = "varchar(250)")]
    public string NotFixedReason{ get; set; }
 
    [Column(TypeName = "int")]
    public int StatusId { get; set; }
 
    [Column(TypeName = "int")]
    public int Version{ get; set; }
 
    [Column(TypeName = "varchar(250)")]
    public string Comments { get; set; }
 
    public Bug Bug { get; set; }

 
}
}