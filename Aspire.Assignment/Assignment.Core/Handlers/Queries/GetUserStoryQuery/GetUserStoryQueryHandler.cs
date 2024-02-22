using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;

namespace Assignment.Core.Handlers.Queries
{

    public class GetUserStoryQueryHandler : IRequestHandler<GetUserStoryQuery, IEnumerable<UserStoryDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetUserStoryQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserStoryDTO>> Handle(GetUserStoryQuery request, CancellationToken cancellationToken)
        {
            var userStory = await Task.FromResult(_repository.UserStory.GetAll());

            if (userStory == null)
            {
                throw new EntityNotFoundException($"No User Story found");
            }

            return _mapper.Map<IEnumerable<UserStoryDTO>>(userStory);
        }
    }
}