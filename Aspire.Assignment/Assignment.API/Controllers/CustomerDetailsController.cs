using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.DTO;
using Assignment.Core.Exceptions;
using Assignment.Core.Handlers.Queries;
using Assignment.Providers.Handlers.Commands;
using Assignment.Providers.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
 
namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(Roles = "user")]
    public class CustomerDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        public CustomerDetailsController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }
 
        [HttpGet]
        public async Task<IActionResult> GetAsync(){
            var query= new GetCustomerDetailsQuery();
            var response= await _mediator.Send(query);
            return Ok(response);
        }
 
        

    }
}
