using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assignment.Contracts.Data.Entities;
using System.Collections.Generic;
namespace Assignment.Contracts.Data.Entities
{
 

public class CustomerSupport : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column(TypeName = "int" )]
    [ForeignKey("User")]
    public int Responsible { get; set;}    
 
    [Column(TypeName = "int")]

    [ForeignKey("CustomerDetails")]
    public int CustomerId{get;set;}
 
    [Column(TypeName = "varchar(250)")]
    public string Details{ get; set; }
   
    [Column(TypeName = "int")]
    public int Version{ get; set; }
    [Column(TypeName = "int")]
    [ForeignKey("user")]

    public int CreatedBy{ get; set; }
 
    [Column(TypeName = "varchar(250)")]
    public string Comments { get; set; }
    [ForeignKey("Status")]
    public int StatusId { get; set; }

    public User User { get; set; }

    public User user { get; set; }

    public Status Status { get; set; }
 
    public List<CustomerDetails> Customer { get; set; }
}
}