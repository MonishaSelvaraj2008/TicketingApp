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
    public class UpdateUserStoryCommand : IRequest<int>
    {
        public UpdateUserStoryDTO Model { get; }
        public UpdateUserStoryCommand(UpdateUserStoryDTO model)
        {
            this.Model = model;
        }
    }
}
