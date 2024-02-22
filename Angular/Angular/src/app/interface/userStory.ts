import { Status } from "./status";
import { User } from "./user";

export interface UserStory {
    Id: number;
    Responsible: string;
    StoryPoint: number;
    AcceptanceCriteria: string;
    Description: string;
    CreatedBy : number;
    StatusId: number;
    Version: number;
    Comments: string;
    AddedOn: string;
    User?: User;
    Status?: Status;
  }
  
 