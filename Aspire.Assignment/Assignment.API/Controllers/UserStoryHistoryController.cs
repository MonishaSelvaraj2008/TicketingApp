using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.DTO;
using Assignment.Core.Exceptions;
using Assignment.Core.Handlers.Commands;
using Assignment.Core.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStoryHistoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        public UserStoryHistoryController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpGet("UserStoryId")]
        [ProducesResponseType(typeof(UserStoryDTO), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> GetUserStoryById([FromQuery] GetUserStoryHistoryByUserStoryIdQuery getUserStoryHistoryByUserIdQuery)
        {
            try
            {
                var response = await _mediator.Send(getUserStoryHistoryByUserIdQuery);
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