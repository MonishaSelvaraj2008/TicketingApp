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
    public class UpdateCustomerSupportCommand : IRequest<int>
    {
        public UpdateCustomerSupportDTO? Model { get; set;}
         public UpdateCustomerSupportCommand(UpdateCustomerSupportDTO UpdateCustomerSupportDTO){
            this.Model = UpdateCustomerSupportDTO;
         }
    }
}

