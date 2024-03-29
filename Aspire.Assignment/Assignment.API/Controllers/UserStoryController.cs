using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Assignment.Contracts.DTO;
using Assignment.Core.Exceptions;
using Assignment.Core.Handlers.Commands;
using Assignment.Core.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Assignment.Contracts.Data.Entities;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        public UserStoryController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        
        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> CreateUserStory([FromBody] CreateUserStoryDTO createUserStoryDTO)
        {
            try
            {
                var createUserStoryCommand = new CreateUserStoryCommand(createUserStoryDTO);
                var response = await _mediator.Send(createUserStoryCommand);
                return StatusCode((int)HttpStatusCode.Created, response);
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

        [HttpPut]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> UpdateUserStory([FromBody] UpdateUserStoryDTO updateUserStoryDTO)
        {
            try
            {
                var command = new UpdateUserStoryCommand(updateUserStoryDTO);
                var response = await _mediator.Send(command);
                return StatusCode((int)HttpStatusCode.Created, response);
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

        [HttpGet("UserStoryId")]
        [ProducesResponseType(typeof(UserStoryDTO), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> GetUserStoryById([FromQuery] GetUserStoryByIdQuery getUserStoryByIdQuery)
        {
            try
            {
                var response = await _mediator.Send(getUserStoryByIdQuery);
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
        [HttpGet("CreatedBy")]
        [ProducesResponseType(typeof(IEnumerable<UserStory>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> GetUserStoryByCreatedBy([FromQuery]GetUserStoryByCreatedByQuery getUserStoryByCreatedByQuery)
        {
            try
            {
                var response = await _mediator.Send(getUserStoryByCreatedByQuery);
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

        [HttpGet("Responsible")]
        [ProducesResponseType(typeof(IEnumerable<UserStory>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> GetUserStoryByResponsible([FromQuery]GetUserStoryByResponsibleQuery getUserStoryByResponsibleQuery)
        {
            try
            {
                var response = await _mediator.Send(getUserStoryByResponsibleQuery);
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



    }
}