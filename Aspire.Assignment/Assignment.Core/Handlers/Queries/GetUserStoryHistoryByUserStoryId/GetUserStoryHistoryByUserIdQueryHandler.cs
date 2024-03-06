using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;
using Assignment.Contracts.Data.Entities;
 
namespace Assignment.Core.Handlers.Queries
{
 
    public class GetUserStoryHistoryByUserStoryIdQueryHandler : IRequestHandler<GetUserStoryHistoryByUserStoryIdQuery, IEnumerable<UserStoryHistoryDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
 
        public GetUserStoryHistoryByUserStoryIdQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
 
        public async Task<IEnumerable<UserStoryHistoryDTO>> Handle(GetUserStoryHistoryByUserStoryIdQuery request, CancellationToken cancellationToken)
        {
            var userStoryHistory = await Task.FromResult(_repository.UserStoryHistory.GetUserStoryHistory(request.UserStoryId));
            if (userStoryHistory == null)
            {
                throw new EntityNotFoundException($"No User Story found of Id: " + request.UserStoryId);
            }
 
           // List<UserStoryHistory> userStoryHistories = userStoryHistory.ToList();
            return userStoryHistory;
        }
    }
}