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
    public class CreateBugCommand : IRequest<int>
    {
        public CreateBugDTO? Model { get;}
        public CreateBugCommand(CreateBugDTO createBugDTO){
            this.Model = createBugDTO;
        }

    }
}
