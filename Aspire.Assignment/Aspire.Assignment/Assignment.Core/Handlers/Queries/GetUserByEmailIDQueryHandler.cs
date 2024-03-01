// using MediatR;
// using Assignment.Contracts.DTO;
// using Assignment.Contracts.Data;
// using Assignment.Core.Exceptions;
// using AutoMapper;

// namespace Assignment.Providers.Handlers.Queries
// {
//     public class GetUserByEmailIDQuery : IRequest<UserDTO>
//     {
//         public string EmailID { get; }
//         public GetUserByEmailIDQuery(string emailID)
//         {
//             EmailID = emailID;
//         }
     
//     }

//     public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByEmailIDQuery, UserDTO>
//     {
//         private readonly IUnitOfWork _repository;
//         private readonly IMapper _mapper;

//         public GetUserByUserNameQueryHandler(IUnitOfWork repository, IMapper mapper)
//         {
//             _repository = repository;
//             _mapper = mapper;
//         }

//         public async Task<UserDTO> Handle(GetUserByEmailIDQuery request, CancellationToken cancellationToken)
//         {
//             var app = await Task.FromResult(_repository.User.Get(request.EmailID));

//             if (app == null)
//             {
//                 throw new EntityNotFoundException($"No App found for Id {request.EmailID}");
//             }

//             return _mapper.Map<UserDTO>(app);
//         }
//     }
// }