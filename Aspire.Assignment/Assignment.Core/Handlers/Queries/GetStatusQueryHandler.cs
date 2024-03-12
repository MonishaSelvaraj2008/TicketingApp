using AutoMapper;
using Assignment.Contracts.Data;
using Assignment.Contracts.DTO;
using MediatR;
namespace Assignment.Providers.Handlers.Queries
{
    public class GetStatusQuery:IRequest<IEnumerable<StatusDTO>>
    {
   
    }
    public class GetStatusQueryHandler : IRequestHandler<GetStatusQuery, IEnumerable<StatusDTO>>
        {
            private readonly IUnitOfWork _repository;
            private readonly IMapper _mapper;
   
            public GetStatusQueryHandler(IUnitOfWork repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
   
            public async Task<IEnumerable<StatusDTO>> Handle(GetStatusQuery request, CancellationToken cancellationToken)
            {
                var entities = await Task.FromResult(_repository.Status.GetAll());
                return _mapper.Map<IEnumerable<StatusDTO>>(entities);
            }
        }
}