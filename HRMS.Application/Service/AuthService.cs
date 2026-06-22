using HRMS.Application.DTOs;
using HRMS.Application.Interface;
using HRMS.Domain.Entity;
using HRMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace HRMS.Application.Service
{
    public class AuthService : IAuthService
    {
        private readonly HrmsDbContext _hrmsDbContext;
        private readonly IConfiguration _configuration;
        public AuthService(HrmsDbContext hrmsDbContext,IConfiguration configuration)
        {
            _hrmsDbContext = hrmsDbContext;
            _configuration = configuration;
        }

        public async Task<ApiResponse<UserDto>> LoginAsync(LoginRequestDto data)
        {
            // passward 
           
            var user = await _hrmsDbContext.Users 
                    .FirstOrDefaultAsync(x => x.UserName == data.UserName | x.Email == data.UserName);

            if (user == null)
            {
                return new ApiResponse<UserDto>
                {
                    Success = false,
                    Message = "Invalid username or password"
                };
            }

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(data.Password,user.PasswordHash);

            if (!isValidPassword)
            {
                return new ApiResponse<UserDto>
                {
                    Success = false,
                    Message = "Invalid username or password"
                };
            }

            string token = GenerateJwtToken(user);

            return new ApiResponse<UserDto>
            {
                Success = true,
                Message = "Login successful",
                Data = new UserDto
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Email = user.Email,
                    token = token
                }
            };
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(_configuration["Jwt:ExpiryMinutes"])),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        } 
    }
}
