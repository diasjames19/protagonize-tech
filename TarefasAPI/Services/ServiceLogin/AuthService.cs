using TarefasAPI.Models;
using TarefasAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TarefasAPI.Services;

public class LoginService
{
     private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public LoginService(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public string Authenticate(Login login)
        {
            
            var user = _context.Users
                .FirstOrDefault(u => u.Email == login.Email && u.Pass == login.Pass);

            if (user == null)
                return null;

            var claims = new[]
            {
                //new Claim(ClaimTypes.Name, user.Email)
                new Claim("Id", user.Id.ToString(), user.Email)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public Users GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
    }

