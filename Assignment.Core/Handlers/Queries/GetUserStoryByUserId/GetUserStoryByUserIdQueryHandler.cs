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
            var userStory = await Task.FromResult(_repository.UserStory.GetUserStory(request.CreatedBy));
            if (userStory == null)
            {
                throw new EntityNotFoundException($"No User Story found of Id: " + request.CreatedBy);
            }
            return userStory;

        }
    }
}