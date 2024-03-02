using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Contracts.Data.Entities;

namespace Assignment.Contracts.DTO
{
    public class UserStoryDTO
    {
    public int Id { get; set; } 

     public int Responsible { get; set;}    
     public string ResponsibleName { get; set; }
    public int StoryPoint { get; set; }
    public string AcceptanceCriteria { get; set; }

    public string Description { get; set; }
    public int CreatedBy{ get; set; }
    public int StatusId { get; set; }
    public string Status { get; set; }
    public int Version { get; set; }

    public string Comments { get; set; }

    }
}
