import { Status } from "./status";
import { User } from "./user";

export interface UserStory {
    Id: number;
    Responsible: number;
    StoryPoint: number;
    AcceptanceCriteria: string;
    Description: string;
    CreatedBy : number;
    StatusId: number;
    Version: number;
    Comments: string;
    AddedOn: Date;
    User?: User;
    Status?: Status;
  }
  
 