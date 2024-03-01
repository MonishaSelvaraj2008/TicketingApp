using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assignment.Contracts.Data.Entities;
namespace Assignment.Contracts.Data.Entities
{

public class Status 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get ; set;}

    [Column(TypeName = "varchar(50)" )]
     public string State {get; set;}
  
}
}