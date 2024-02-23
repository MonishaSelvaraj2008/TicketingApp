using MediatR;
using Assignment.Contracts.Data;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data.Entities;
using FluentValidation;
using System.Text.Json;
using Assignment.Core.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Assignment.Core.Handlers.Commands
{
    public class CreateUserStoryCommand : IRequest<int>
    {
        public CreateUserStoryDTO? Model { get;}

        public CreateUserStoryCommand(CreateUserStoryDTO createUserStoryDTO){
            this.Model = createUserStoryDTO;
        }

    }
}
