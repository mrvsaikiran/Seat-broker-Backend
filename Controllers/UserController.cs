using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seat_broker_backend.Context;
using Seat_broker_backend.Helpers;
using Seat_broker_backend.Models;
using System.IdentityModel.Tokens.Jwt;
using System;  
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Seat_broker_backend.Repository.Implentations;

namespace Seat_broker_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepostory _userRepository;
       public UserController(UserRepostory userRepository) {
          
            _userRepository = userRepository;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if(userObj == null)
            {
                return BadRequest();
            }
            if (userObj.UserName == null) { return BadRequest(new { Message = "UserName or Email Id  is  Mandatory" }); }


            if (userObj.Password == null) { return BadRequest(new { Message = "Password Field is Not Present " }); }


            var user = await _userRepository.GetUserByEmail(userObj.Email);
            if(user == null)
            {
                return NotFound(new { Message = "User Not Found" });

            }
            if (PasswordHasher.VerifyPassword(user.Password, userObj.Password)) {
                { return BadRequest(new { Message = "Password is incorrect" }); }
            }

            user.Token = CreateToken(user);
            return Ok(new { 
                Token=user.Token,
                Message = "Login Success" });
        }


        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if (userObj == null) { return BadRequest(); }

            if (userObj.UserName == null) { return BadRequest(new { Message = "UserName is Not Present" }); }

            if (userObj.Email == null) { return BadRequest(new { Message = "User Email field  is Not Present" }); }

            if (userObj.Password == null) { return BadRequest(new { Message = "Password Field is Not Present " }); }

            var EmailAlreadyExists = await _userRepository.GetUserByEmail(userObj.Email);

            if(EmailAlreadyExists != null)
            {
                return BadRequest(new { Message = "Email address is already registered. Please choose a different email." });
            }
            userObj.Password=PasswordHasher.HashPassword(userObj.Password);
            userObj.UserType= "User";
            userObj.Token = "";

            await _userRepository.AddUser(userObj);
            return Ok(new {Message ="User Registered Sucessfully !!!"});
        }
    
        private string CreateToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Secret....!!!");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role,user.UserType),
                new Claim(ClaimTypes.Name,user.UserName),
            });

            var Crendentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256);
            var tokenDescripter = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = Crendentials
            };
            var token =jwtTokenHandler.CreateToken(tokenDescripter);

            return jwtTokenHandler.WriteToken(token);




        
        }

       
    }
}
