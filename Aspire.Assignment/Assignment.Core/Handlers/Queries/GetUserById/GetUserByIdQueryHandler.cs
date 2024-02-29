using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;

namespace Assignment.Core.Handlers.Queries
{

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, CreateUsersDTO>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        public GetUserByIdQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
 
        public async Task<CreateUsersDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await Task.FromResult(_repository.User.Get(request.UserId));
 
            if (user == null)
            {
                throw new EntityNotFoundException($"No User found of Id: " + request.UserId);
            }

            return _mapper.Map<CreateUsersDTO>(user);//user is the instance of User, and AutoMapper will map properties from this User object to properties in a new instance of CreateUsersDTO
        }
    }
}