// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.IdentityModel.Tokens.Jwt;
// using System.Net;
// using System.Security.Claims;
// using System.Text;
// using System.Threading.Tasks;
// using Assignment.Contracts.DTO;
// using Assignment.Core.Exceptions;
// using Assignment.Providers.Handlers.Queries;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Configuration;
// using Microsoft.IdentityModel.Tokens;

// namespace Assignment.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class UserController : ControllerBase
//     {
//         private readonly IMediator _mediator;
//         private readonly IConfiguration _configuration;
//         public UserController(IMediator mediator, IConfiguration configuration)
//         {
//             _mediator = mediator;
//             _configuration = configuration;
//         }

//         [HttpGet]
//         [Route("{emailid}")]
//         [ProducesResponseType(typeof(UserDTO), (int)HttpStatusCode.OK)]
//         [ProducesErrorResponseType(typeof(BaseResponseDTO))]
//         public async Task<IActionResult> GetByEmailID(string EmailID)
//         {
//             try
//             {
//                 var query = new GetUserByEmailIDQuery(EmailID);
//                 var response = await _mediator.Send(query);
//                 return Ok(response);
//             }
//             catch (EntityNotFoundException ex)
//             {
//                 return NotFound(new BaseResponseDTO
//                 {
//                     IsSuccess = false,
//                     Errors = new string[] { ex.Message }
//                 });
//             }
//         }
//     }
// }