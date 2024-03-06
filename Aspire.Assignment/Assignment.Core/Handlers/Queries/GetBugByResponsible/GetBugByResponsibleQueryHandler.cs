using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;
 
namespace Assignment.Core.Handlers.Queries
{
 
    public class GetBugByResponsibleQueryHandler : IRequestHandler<GetBugByResponsibleQuery, IEnumerable<BugDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
 
        public GetBugByResponsibleQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
 
        public async Task<IEnumerable<BugDTO>> Handle(GetBugByResponsibleQuery request, CancellationToken cancellationToken)
        {
            var bug = await Task.FromResult(_repository.Bug.GetBugByResponsible(request.Responsible));
            if (bug == null)
            {
                throw new EntityNotFoundException($"No Bug found of Id: " + request.Responsible);
            }
            return bug;
            //return bug;
 
        }
    }
}