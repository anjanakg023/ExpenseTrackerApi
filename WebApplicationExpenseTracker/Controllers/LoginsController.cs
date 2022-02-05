using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationExpenseTracker.Models;
using WebApplicationExpenseTracker.Repository;

namespace WebApplicationExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {

   

        #region token
        //1. dependecy injection for configuration



        private readonly IConfiguration _config;



        //2. constructor injection
        public LoginsController(IConfiguration config)
        {
            _config = config;
        }



        //3. httppost
        [HttpPost("token")]



        public IActionResult Login([FromBody] Login user)
        {
            //checking unauthorized



            IActionResult response = Unauthorized();



            //authenticate the user
            var loginUser = AuthenticateUser(user);



            if (loginUser != null)
            {
                var tokenString = GenerateJWToken(loginUser);
                response = Ok(new { token = tokenString });
            }
            return response;
        }



        //4. authenticate user
        private Login AuthenticateUser(Login user)
        {

           Login loginUser = null;
            if (user.LoginId == "Anjana")
            {
                loginUser = new Login
                {
                    LoginId = "Anjana",
                    Password = "An123"
                };
            }
            return loginUser;



        }





        //5. generate jwt token



        private string GenerateJWToken(Login loginUser)
        {
            //security key
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));



            //signing credential
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);



            //generate tokens
            var token = new JwtSecurityToken(
            _config["Jwt:Issuer"], //header
            _config["Jwt:Issuer"],
            expires: DateTime.Now.AddMinutes(2),
            signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
    #endregion


    
}

