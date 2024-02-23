using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assignment.Contracts.Data.Entities;
namespace Assignment.Contracts.Data.Entities
{
 
public class CustomerSupportHistory : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column(TypeName = "int")]
    
     [ForeignKey("CustomerSupport")]
    public int CustomerSupportId { get; set;}
 
    [Column(TypeName = "varchar(250)")]
    public string Details{ get; set; }
    [Column(TypeName = "int" )]
    public int Responsible { get; set;}    
 
 
    [Column(TypeName = "int")]
    public int Version{ get; set; }
 
    [Column(TypeName = "varchar(250)")]
    public string Comments { get; set; }
    [Column(TypeName = "int")]
    public int StatusId { get; set; }

    public CustomerSupport CustomerSupport { get; set; }

 
}
}