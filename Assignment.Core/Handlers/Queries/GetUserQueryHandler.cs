using AutoMapper;
using Assignment.Contracts.Data;
using Assignment.Contracts.DTO;
using MediatR;
namespace Assignment.Providers.Handlers.Queries
{
    public class GetUserQuery:IRequest<IEnumerable<CreateUsersDTO>>
    {
   
    }
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, IEnumerable<CreateUsersDTO>>
        {
            private readonly IUnitOfWork _repository;
            private readonly IMapper _mapper;
   
            public GetUserQueryHandler(IUnitOfWork repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
   
            public async Task<IEnumerable<CreateUsersDTO>> Handle(GetUserQuery request, CancellationToken cancellationToken)
            {
                var entities = await Task.FromResult(_repository.User.GetAll());
                return _mapper.Map<IEnumerable<CreateUsersDTO>>(entities);
            }
        }
}