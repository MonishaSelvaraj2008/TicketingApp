using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Assignment.Contracts.Data.Entities;
namespace Assignment.Contracts.Data.Entities
{
public class CustomerDetails : BaseEntity
{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }
 
        [Column(TypeName = "varchar(250)")]
        public string CustomerName { get; set; }
 
        [Column(TypeName = "varchar(250)")]
        public string Email { get; set; }
 
        [Column(TypeName = "varchar(20)")]
        public long PhoneNumber { get; set; }
}
}