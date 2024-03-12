export interface Bug {
    description: string;
    environment: string;
    priority: number;
    responsible: number;
    regression: boolean;
    fixedID: string;
    notFixedReason: string;
    comments: string;
    createdBy: number;
}
  