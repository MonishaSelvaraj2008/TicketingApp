using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;
using Assignment.Contracts.Data.Entities;

namespace Assignment.Core.Handlers.Queries
{

    public class GetBugHistoryByBugIdQueryHandler : IRequestHandler<GetBugHistoryByBugIdQuery, IEnumerable<BugHistoryDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetBugHistoryByBugIdQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BugHistoryDTO>> Handle(GetBugHistoryByBugIdQuery request, CancellationToken cancellationToken)
        {
            var bugHistory = await Task.FromResult(_repository.BugHistory.GetBugHistory(request.BugId));

            if (bugHistory == null)
            {
                throw new EntityNotFoundException($"No Bug History  found of Id: " + request.BugId);
            }

            return bugHistory;
        }
    }
}