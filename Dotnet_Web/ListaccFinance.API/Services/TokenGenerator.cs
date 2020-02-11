using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ListaccFinance.API.Data.Model;
using ListaccFinance.API.Interfaces;
using ListaccFinance.API.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ListaccFinance.API.Services

{
    public class TokenGenerator : ITokenGenerator
    {

        private readonly IConfiguration _config;

        public TokenGenerator (IConfiguration config) 
        {
            _config = config;
        }
        public async Task<string> GenerateToken(DesktopClient i) {



            var tokenClaims = new List<Claim>{};
            tokenClaims.Add(new Claim("Desktopid", i.Id.ToString()));
            tokenClaims.Add(new Claim("name", i.ClientName));
            tokenClaims.Add(new Claim("type", i.ClientType));
            tokenClaims.Add(new Claim("macAddr", i.ClientMacAddress));
            
            var keyByte = Encoding.UTF8.GetBytes(_config.GetSection("LoginSettings:Key").Value);
            
            var key = new SymmetricSecurityKey(keyByte);
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(tokenClaims),
                SigningCredentials = credentials,
                Expires = DateTime.Now.AddMonths(1),
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            
            return tokenString;
        }

        public async Task<string> GenerateToken(UserLogin u, int ID)
        {
            var tokenClaims = new List<Claim> { };
            tokenClaims.Add(new Claim("UserID", ID.ToString()));
            tokenClaims.Add(new Claim("email", u.EmailAddress));
            tokenClaims.Add(new Claim("password", u.Password));

            var keyByte = Encoding.UTF8.GetBytes(_config.GetSection("LoginSettings:Key").Value);

            var key = new SymmetricSecurityKey(keyByte);
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(tokenClaims),
                SigningCredentials = credentials,
                Expires = DateTime.Now.AddDays(3),
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);


            return tokenString;
        }
    }    
}