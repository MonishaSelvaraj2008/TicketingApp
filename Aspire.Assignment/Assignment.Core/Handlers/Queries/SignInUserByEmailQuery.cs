using MediatR;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data;
using Assignment.Core.Exceptions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Assignment.Contracts.Data.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
 
namespace Assignment.Providers.Handlers.Queries
{
    public class SignInUserByEmailQuery : IRequest<TokenResponseDTO>
    {
        public CreateUsersDTO dto { get; }
        public SignInUserByEmailQuery(CreateUsersDTO createUsersDTO)
        {
            this.dto = createUsersDTO;
        }
    }
 
    public class SignInUserByUserNameQueryHandler : IRequestHandler<SignInUserByEmailQuery, TokenResponseDTO>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _configuration;
   
 
 
        public SignInUserByUserNameQueryHandler(IUnitOfWork repository, IMapper mapper, IPasswordHasher<User> passwordHasher, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
           
        }
 
        public async Task<TokenResponseDTO> Handle(SignInUserByEmailQuery request, CancellationToken cancellationToken)
        {
 
           
            var user = await Task.FromResult(_repository.User.GetAll().Where(con=>con.Email.Equals(request.dto.Email)).FirstOrDefault());
 
            if (user == null)
            {
                throw new EntityNotFoundException($"No User found for  {request.dto.Email}");
            }
            PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(user, user.Password, request.dto.Password);
            if(PasswordVerificationResult.Success!=result)
            {
                throw new InvalidcredentialsException($"Invalid credentials");
            }
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Authentication:Jwt:Secret").Value);
 
                var accessTokenExpires = DateTime.UtcNow.AddMinutes(15);
                var refreshTokenExpires = DateTime.UtcNow.AddDays(7);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("email", request.dto.Email), new Claim(ClaimTypes.Role, "user") }),
                    Expires = DateTime.UtcNow.AddMinutes(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
 
                var token= tokenHandler.CreateToken(tokenDescriptor);
 
                var refreshToken = GenerateRefreshToken();
             
                return new TokenResponseDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Mobile = user.Mobile,
                    Email = user.Email,
                    AccessToken = tokenHandler.WriteToken(token),
                    AccessTokenExpiration = accessTokenExpires,
                    RefreshToken = refreshToken,
                    RefreshTokenExpiration = refreshTokenExpires
                };
        }
 
        private string GenerateRefreshToken()
        {
            // Generate a random refresh token
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}