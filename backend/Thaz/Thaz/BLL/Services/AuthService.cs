using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Thaz.BLL.Model;
using Thaz.BLL.Repositories;
using Thaz.DAL.Repositories;

namespace Thaz.BLL.Services
{
    public class AuthService
    {
        public AuthService(IConfiguration config, IAuthRepository authRepository)
        {
            Config = config;
            AuthRepository = authRepository;
        }

        private IConfiguration Config { get; }
        public IAuthRepository AuthRepository { get; }

        public string GenerateJsonWebToken(User user)    
        {    
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["Jwt:Key"]));    
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    
    
            var claims = new[] {    
                new Claim(nameof(User.Email), user.Email),    
                new Claim(nameof(User.Name), user.Name),    
                new Claim(nameof(User.Id), user.Id.ToString()),    
            };   
            
            var token = new JwtSecurityToken(Config["Jwt:Issuer"],    
                Config["Jwt:Issuer"],    
                claims,    
                expires: DateTime.Now.AddMinutes(120),    
                signingCredentials: credentials);
            

    
            return new JwtSecurityTokenHandler()
                .WriteToken(token);    
        }    
    
        public User AuthenticateUser(string email, string password)
        {
            User user = AuthRepository.Login(email, password);
            return user;    
        }
    }
}