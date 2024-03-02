using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Assignment.Contracts.DTO
{
    public class BugDTO
    {
    public int Id { get; set; }
    public string Description{ get; set; }
    public string Environment{ get; set; }
    public int Priority{ get; set; }
    public int Responsible{ get; set; }
    public string ResponsibleName { get; set; }
    public bool Regression{ get; set; }
    public string FixedID{ get; set; }
    public string NotFixedReason{ get; set; }
    public int CreatedBy{ get; set; }
    public int StatusId { get; set; }
    public string Status { get; set; }
    public int Version{ get; set; }
    public string Comments { get; set; }

    }
}
 