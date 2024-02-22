using AutoMapper;
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.DTO;

namespace Assignment.Core.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateBugDTO,Bug>().ReverseMap();
            CreateMap<BugDTO,Bug>().ReverseMap();
            CreateMap<IEnumerable<BugDTO>,IEnumerable<Bug>>().ReverseMap();
            
            CreateMap<CreateUserStoryDTO,UserStory>().ReverseMap();
            CreateMap<UserStoryDTO,UserStory>().ReverseMap();
            CreateMap<IEnumerable<UserStoryDTO>,IEnumerable<UserStory>>().ReverseMap();

            CreateMap<UpdateUserStoryDTO,UserStory>().ReverseMap();
            CreateMap<UserStoryDTO,UserStory>().ReverseMap();
            CreateMap<IEnumerable<UserStoryDTO>,IEnumerable<UserStory>>().ReverseMap();
        }
    }
}
