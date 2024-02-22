using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;

namespace Assignment.Core.Handlers.Queries
{

    public class GetUserStoryByUserIdQueryHandler : IRequestHandler<GetUserStoryByUserIdQuery, UserStoryDTO>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetUserStoryByUserIdQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserStoryDTO> Handle(GetUserStoryByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userStory = await Task.FromResult(_repository.UserStory.Get(request.CreatedBy));
            if (userStory == null)
            {
                throw new EntityNotFoundException($"No User Story found of Id: " + request.CreatedBy);
            }
            return _mapper.Map<UserStoryDTO>(userStory);
        }
    }
}