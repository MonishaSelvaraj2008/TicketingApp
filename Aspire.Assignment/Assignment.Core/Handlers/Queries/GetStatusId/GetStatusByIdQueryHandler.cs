using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;

namespace Assignment.Core.Handlers.Queries
{

    public class GetStatusByIdQueryHandler : IRequestHandler<GetStatusByIdQuery, StatusDTO>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public GetStatusByIdQueryHandler(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StatusDTO> Handle(GetStatusByIdQuery request, CancellationToken cancellationToken)
        {
            var status = await Task.FromResult(_repository.Status.Get(request.StatusId));

            if (status == null)
            {
                throw new EntityNotFoundException($"No Status found of Id: " + request.StatusId);
            }

            return _mapper.Map<StatusDTO>(status);
        }
    }
}