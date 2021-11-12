using BankingManagementSystem.Service.Helpers;
using BankingManagementSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BankingManagementSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IConfiguration _configuration;

        public AccountController(ICustomerService customerService, IConfiguration configuration)
        {
            _customerService = customerService;
            _configuration = configuration;
        }

        [HttpPost("gettoken")]
        public IActionResult Post()
        {
            if(!Request.Headers.ContainsKey("Authorization"))
            {
                return BadRequest("Authorization Headers absent in the request");
            }

            var authHeader = Request.Headers["Authorization"].ToString();
            if (!authHeader.StartsWith("Basic "))
                return BadRequest("Invalid request");
            var creds = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Substring("Basic ".Length).Trim())).Split(":");

            if(creds.Length != 2)
            {
                return BadRequest("Invalid Credentials");
            }

            var customer = _customerService.GetCustomerByUserNameAndPassword(creds[0], EncryptionHelper.Encrypt(creds[1],
                _configuration.GetValue<string>("AppSettings:PassPhrase"),
                _configuration.GetValue<string>("AppSettings:Salt"),
                _configuration.GetValue<string>("AppSettings:InitVector")));

            if (customer != null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, customer.UserName),
                    new Claim(ClaimTypes.Role, "Customer"),
                    new Claim("CustomerId", customer.Id.ToString()) 
                };

                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:IssuerSigningKey")));
                var signingCredentials = new SigningCredentials(key: signingKey, algorithm: SecurityAlgorithms.HmacSha256Signature);

                var token = new JwtSecurityToken
                (
                    issuer: _configuration.GetValue<string>("AppSettings:Issuer"),
                    audience: _configuration.GetValue<string>("AppSettings:Audience"),
                    expires: DateTime.Now.AddMinutes(15),
                    claims: claims,
                    signingCredentials: signingCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(tokenString);
            }

            return BadRequest("Username or Password is invalid");
        }
    }
}
