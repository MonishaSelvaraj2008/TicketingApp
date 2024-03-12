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
    public class CustomerSupportController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        public CustomerSupportController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        
        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> CreateCustomerSupport([FromBody] CreateCustomerSupportDTO createCustomerSupportDTO)
        {
            try
            {
                var createCustomerSupportCommand = new CreateCustomerSupportCommand(createCustomerSupportDTO);
                var response = await _mediator.Send(createCustomerSupportCommand);
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
        public async Task<IActionResult> UpdateCustomerSupport([FromBody] UpdateCustomerSupportDTO updateCustomerSupportDTO)
        {
            try
            {
                var command = new UpdateCustomerSupportCommand(updateCustomerSupportDTO);
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
       

        [HttpGet("CustomerSupportId")]
        [ProducesResponseType(typeof(CustomerSupportDTO), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> GetCustomerSupportById([FromQuery] GetCustomerSupportByIdQuery getCustomerSupportByIdQuery)
        {
            try
            {
                var response = await _mediator.Send(getCustomerSupportByIdQuery);
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
        [ProducesResponseType(typeof(IEnumerable<CustomerSupport>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> GetCustomerSupportByCreatedBy([FromQuery]GetCustomerSupportByCreatedByQuery getCustomerSupportByCreatedByQuery)
        {
            try
            {
                var response = await _mediator.Send(getCustomerSupportByCreatedByQuery);
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
        [ProducesResponseType(typeof(IEnumerable<CustomerSupport>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> GetCustomerSupportByResponsible([FromQuery]GetCustomerSupportByResponsibleQuery getCustomerSupportByResponsibleQuery)
        {
            try
            {
                var response = await _mediator.Send(getCustomerSupportByResponsibleQuery);
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