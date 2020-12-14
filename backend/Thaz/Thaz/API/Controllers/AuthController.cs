using Microsoft.AspNetCore.Authorization;    
using Microsoft.AspNetCore.Mvc;    
using Microsoft.Extensions.Configuration;    
using Microsoft.IdentityModel.Tokens;    
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;    
using System.Security.Claims;    
using System.Text;
using Thaz.API.DTOs;
using Thaz.BLL.Services;

namespace Thaz.API.Controllers
{
    [Route("auth")]    
    [ApiController]    
    public class AuthController : Controller    
    {
        public AuthController(AuthService authService)
        {
            AuthService = authService;
        }

        private AuthService AuthService { get; }
        [AllowAnonymous]    
        [HttpPost]    
        public ActionResult<LoginResponse> Login([FromBody]LoginRequest loginRequest)    
        {    
            var user = AuthService.AuthenticateUser(loginRequest.Email, loginRequest.Password);    
    
            if (user != null)    
            {    
                var tokenString = AuthService.GenerateJsonWebToken(user);    
                return Ok(new LoginResponse(){ Token = tokenString, Email = user.Email, Name = user.Name});    
            }
    
            return Unauthorized();     
        }    
    

        
        [HttpGet]    
        [Authorize]    
        public ActionResult<IEnumerable<string>> Get()    
        {    
            return new string[] { "value1", "value2", "value3", "value4", "value5" };    
        } 
    }    
}   