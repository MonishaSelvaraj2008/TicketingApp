using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;
 
namespace Assignment.Core.Handlers.Queries
{
 
    public class GetUserStoryByCreatedByQueryHandler : IRequestHandler<GetUserStoryByCreatedByQuery, IEnumerable<UserStoryDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
 
        public GetUserStoryByCreatedByQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
 
        public async Task<IEnumerable<UserStoryDTO>> Handle(GetUserStoryByCreatedByQuery request, CancellationToken cancellationToken)
        {
            var userStory = await Task.FromResult(_repository.UserStory.GetUserStory(request.CreatedBy));
            if (userStory == null)
            {
                throw new EntityNotFoundException($"No User Story found of Id: " + request.CreatedBy);
            }
 
            if (!string.IsNullOrEmpty(request.Search))
            {
                userStory = userStory.Where(obj => obj.ResponsibleName.ToString().ToLower().Contains(request.Search.ToLower()) ||
                                                obj.Status.ToString().ToLower().Contains(request.Search.ToLower()) ||
                                                obj.Description.ToString().ToLower().Contains(request.Search.ToLower()) ||
                                                obj.StoryPoint.ToString().ToLower().Contains(request.Search.ToLower()) ||
                                                obj.AcceptanceCriteria.ToString().ToLower().Contains(request.Search.ToLower()) ||
                                                obj.Comments.ToString().ToLower().Contains(request.Search.ToLower()));
 
            }
            return userStory;
 
        }
    }
}
