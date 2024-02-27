import { Bug } from "./bug";
import { CustomerSupport } from "./customerSupport";
import { UserStory } from "./userStory";

export interface User {
    Id: number;
    FirstName: string;
    LastName: string;
    Mobile: string;
    Email: string;
    Password: string;
}