export interface Bug {
    Id: number;
    Description: string;
    Environment: string;
    Priority: number;
    Responsible: number;
    Regression: boolean;
    FixedID: string;
    NotFixedReason: string;
    CreatedBy: number;
    StatusId: number;
    Version: number;
    Comments: string;
  }
  