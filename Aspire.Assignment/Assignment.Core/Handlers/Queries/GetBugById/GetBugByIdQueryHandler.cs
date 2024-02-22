using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;

namespace Assignment.Core.Handlers.Queries
{

    public class GetBugByIdQueryHandler : IRequestHandler<GetBugByIdQuery, BugDTO>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetBugByIdQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BugDTO> Handle(GetBugByIdQuery request, CancellationToken cancellationToken)
        {
            var bug = await Task.FromResult(_repository.Bug.Get(request.BugId));

            if (bug == null)
            {
                throw new EntityNotFoundException($"No Bug found of Id: " + request.BugId);
            }

            return _mapper.Map<BugDTO>(bug);
        }
    }
}