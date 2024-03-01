using System.ComponentModel.DataAnnotations.Schema;
namespace Assignment.Contracts.Data.Entities
{
    public class BaseEntity
    {
        [Column(TypeName = "datetime" )]
        public virtual DateTime AddedOn {get; set;}

    }
}
