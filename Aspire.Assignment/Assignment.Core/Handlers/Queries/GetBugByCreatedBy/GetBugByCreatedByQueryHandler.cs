using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;
 
namespace Assignment.Core.Handlers.Queries
{
 
    public class GetBugByCreatedByQueryHandler : IRequestHandler<GetBugByCreatedByQuery, IEnumerable<BugDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
 
        public GetBugByCreatedByQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
 
        public async Task<IEnumerable<BugDTO>> Handle(GetBugByCreatedByQuery request, CancellationToken cancellationToken)
        {
            var bug = await Task.FromResult(_repository.Bug.GetBugByCreatedBy(request.CreatedBy));
            if (bug == null)
            {
                throw new EntityNotFoundException($"No Bug found of Id: " + request.CreatedBy);
            }
            return bug;
            //return bug;
 
        }
    }
}