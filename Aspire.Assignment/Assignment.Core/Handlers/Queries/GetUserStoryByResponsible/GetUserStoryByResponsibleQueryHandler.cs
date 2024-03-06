using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;
 
namespace Assignment.Core.Handlers.Queries
{
 
    public class GetUserStoryByResponsibleQueryHandler : IRequestHandler<GetUserStoryByResponsibleQuery, IEnumerable<UserStoryDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
 
        public GetUserStoryByResponsibleQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
 
        public async Task<IEnumerable<UserStoryDTO>> Handle(GetUserStoryByResponsibleQuery request, CancellationToken cancellationToken)
        {
            var userStory = await Task.FromResult(_repository.UserStory.GetUserStoryByResponsible(request.Responsible));
            if (userStory == null)
            {
                throw new EntityNotFoundException($"No User Story found of Id: " + request.Responsible);
            }
            return userStory;
            //return userStory;
 
        }
    }
}