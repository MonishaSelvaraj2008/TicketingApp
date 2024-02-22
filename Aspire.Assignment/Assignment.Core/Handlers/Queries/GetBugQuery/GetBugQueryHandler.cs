using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;

namespace Assignment.Core.Handlers.Queries
{

    public class GetBugQueryHandler : IRequestHandler<GetBugQuery, IEnumerable<BugDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetBugQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BugDTO>> Handle(GetBugQuery request, CancellationToken cancellationToken)
        {
            var bug = await Task.FromResult(_repository.Bug.GetAll());

            if (bug == null)
            {
                throw new EntityNotFoundException($"No Bug found");
            }

            return _mapper.Map<IEnumerable<BugDTO>>(bug);
        }
    }
}