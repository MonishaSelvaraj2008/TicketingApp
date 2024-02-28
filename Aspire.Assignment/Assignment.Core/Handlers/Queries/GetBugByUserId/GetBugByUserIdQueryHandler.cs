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
            var bug = await Task.FromResult(_repository.Bug.GetAll().Where(obj=>obj.CreatedBy == request.CreatedBy));
            if (bug == null)
            {
                throw new EntityNotFoundException($"No Bug found of Id: " + request.CreatedBy);
            }
            List<Bug> bugs = bug.ToList();
            return _mapper.Map<List<BugDTO>>(bug);
            //return bug;

        }
    }
}