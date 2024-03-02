using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;
 
namespace Assignment.Core.Handlers.Queries
{
 
    public class GetBugByUserIdQueryHandler : IRequestHandler<GetBugByUserIdQuery, IEnumerable<BugDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
 
        public GetBugByUserIdQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
 
        public async Task<IEnumerable<BugDTO>> Handle(GetBugByUserIdQuery request, CancellationToken cancellationToken)
        {
            var bug = await Task.FromResult(_repository.Bug.GetBug(request.CreatedBy));
            if (bug == null)
            {
                throw new EntityNotFoundException($"No Bug found of Id: " + request.CreatedBy);
            }
            return bug;
            //return bug;
 
        }
    }
}