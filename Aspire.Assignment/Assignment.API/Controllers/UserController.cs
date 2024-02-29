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
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        public UserController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }
 
        [HttpGet]
        public async Task<IActionResult> GetAsync(){
            var query= new GetUserQuery();
            var response= await _mediator.Send(query);
            return Ok(response);
        }
 
        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> Post([FromBody] CreateUsersDTO model)
        {
            try
            {
                var command = new CreateUserCommand(model);
                var response = await _mediator.Send(command);
 
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Authentication:Jwt:Secret"));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("email", model.Email.ToString()), new Claim(ClaimTypes.Role, "user") }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
 
                // Return the user and token in the response
                return Ok(new
                {
                    user = model,
                   
                    //Serializes a JwtSecurityToken into a JWT in Compact Serialization Format.
                    token = tokenHandler.WriteToken(token)
                });
                //return StatusCode((int)HttpStatusCode.Created, response);
            }
            catch (InvalidRequestBodyException ex)
            {
                return BadRequest(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = ex.Errors
                });
            }
        }
 
        [HttpPost("Login")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> PostData([FromBody] CreateUsersDTO model)
        {
            try
            {
                var command = new SignInUserByEmailQuery(model);
                var response = await _mediator.Send(command);
               
                // Return the user and token in the response
                return Ok(response);
               
            }
            catch (InvalidRequestBodyException ex)
            {
                return BadRequest(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = ex.Errors
                });
            }
        }

        [HttpGet("UserId")]
        [ProducesResponseType(typeof(CreateUsersDTO), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> GetUserById([FromQuery] GetUserByIdQuery getUserByIdQuery)
        {
            try
            {
                var response = await _mediator.Send(getUserByIdQuery);
                return Ok(response);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = new string[] { ex.Message }
                });
            }
        }

 
        // [HttpGet("getUsers")]
        // [ProducesResponseType(typeof(CreateUsersDTO), (int)HttpStatusCode.OK)]
        // [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        // public async Task<IActionResult> GetUser()
        // {
        //     try
        //     {
        //         var query = new GetUserQuery();
        //         var response = await _mediator.Send(query);
        //         return Ok(response);
        //     }
        //     catch (EntityNotFoundException ex)
        //     {
        //         return NotFound(new BaseResponseDTO
        //         {
        //             IsSuccess = false,
        //             Errors = new string[] { ex.Message }
        //         });
        //     }
        // }
    }
}
