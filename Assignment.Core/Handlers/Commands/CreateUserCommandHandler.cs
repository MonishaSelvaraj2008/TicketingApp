using MediatR;
using Assignment.Contracts.Data;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data.Entities;
using FluentValidation;
using Assignment.Core.Exceptions;
using Microsoft.AspNetCore.Identity;
 
namespace Assignment.Providers.Handlers.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public CreateUsersDTO Model { get; }
        public CreateUserCommand(CreateUsersDTO model)
        {
            this.Model = model;
        }
    }
 
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUnitOfWork _repository;
        private readonly IValidator<CreateUsersDTO> _validator;
        private readonly IPasswordHasher<User> _passwordHasher;
 
        public CreateUserCommandHandler(IUnitOfWork repository, IValidator<CreateUsersDTO> validator, IPasswordHasher<User> passwordHasher)
        {
            _repository = repository;
            _validator = validator;
            _passwordHasher = passwordHasher;
        }
 
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            CreateUsersDTO model = request.Model;
            
            var result = _validator.Validate(model);
 
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
                throw new InvalidRequestBodyException
                {
                    Errors = errors
                };
            }
 
 
            var entity = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Mobile = model.Mobile,
                Email = model.Email,
 
            };
             entity.Password= _passwordHasher.HashPassword(entity, model.Password);
            _repository.User.Add(entity);
            await _repository.CommitAsync();
 
            return entity.Id;
        }
    }
}