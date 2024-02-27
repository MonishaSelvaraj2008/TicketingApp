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
            // CreateMap<IEnumerable<BugDTO>,IEnumerable<Bug>>().ReverseMap();
            CreateMap<UpdateBugDTO,Bug>().ReverseMap();

            CreateMap<CreateUserStoryDTO,UserStory>().ReverseMap();
            CreateMap<UserStoryDTO,UserStory>().ReverseMap();
            CreateMap<UpdateUserStoryDTO,UserStory>().ReverseMap();

            CreateMap<CreateCustomerSupportDTO,CustomerSupport>().ReverseMap();
            CreateMap<CustomerSupportDTO,CustomerSupport>().ReverseMap();
            // CreateMap<IEnumerable<CustomerSupportDTO>,IEnumerable<CustomerSupport>>().ReverseMap();
            CreateMap<UpdateCustomerSupportDTO,CustomerSupport>().ReverseMap();

            CreateMap<User,CreateUsersDTO>().ReverseMap();
            CreateMap<Status,StatusDTO>().ReverseMap();
            CreateMap<StatusDTO, Status>().ReverseMap();
        }
    }
}
