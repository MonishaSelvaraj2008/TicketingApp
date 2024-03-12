using Assignment.Contracts.Data;
using Assignment.Contracts.DTO;
using Assignment.Core.Exceptions;
using AutoMapper;
using MediatR;

 
namespace Assignment.Core.Handlers.Queries
{
 
    public class GetUserStoryByIdQueryHandler : IRequestHandler<GetUserStoryByIdQuery, UserStoryDTO>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
 
        public GetUserStoryByIdQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
 
        public async Task<UserStoryDTO> Handle(GetUserStoryByIdQuery request, CancellationToken cancellationToken)
        {
             var userStory = await Task.FromResult(_repository.UserStory.GetUserStoryById(request.UserStoryId));
 
            if (userStory == null)
            {
                throw new EntityNotFoundException($"No User Story found of Id: " + request.UserStoryId);
            }
 
            return userStory;
        }
    }
}