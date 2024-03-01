using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;
using Assignment.Contracts.Data.Entities;

namespace Assignment.Core.Handlers.Queries
{

    public class GetUserStoryByUserIdQueryHandler : IRequestHandler<GetUserStoryByUserIdQuery, IEnumerable<UserStoryDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetUserStoryByUserIdQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserStoryDTO>> Handle(GetUserStoryByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userStory = await Task.FromResult(_repository.UserStory.GetAll().Where(obj=>obj.CreatedBy == request.CreatedBy));
            if (userStory == null)
            {
                throw new EntityNotFoundException($"No User Story found of Id: " + request.CreatedBy);
            }
             List<UserStory> userStories = userStory.ToList();
             return _mapper.Map<List<UserStoryDTO>>(userStory);
           // return userStory;

        }
    }
}