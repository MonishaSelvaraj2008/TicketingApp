﻿using Assignment.Contracts.DTO;
 
namespace Assignment.Contracts.Data.Repositories
{
    public interface IBugRepository : IRepository<Bug> {
        IEnumerable<BugDTO> GetBugByCreatedBy(int CreatedBy);
        bool EqualBug(UpdateBugDTO Bug,UpdateBugDTO OldBug);
        BugDTO GetBugById(int BugId);
        public IEnumerable<BugDTO> GetBugByResponsible(int Responsible);
    }
}