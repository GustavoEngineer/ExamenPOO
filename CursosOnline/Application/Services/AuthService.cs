using CursosOnline.Core.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace CursosOnline.Application.Services
{
    public class AuthService
    {
        // Simulación de usuarios en memoria (reemplazar por acceso a BD real)
        private static readonly List<UserRecord> _users = new();
        private readonly IConfiguration _config;

        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
        {
            if (_users.Exists(u => u.Email == dto.Email))
                throw new InvalidOperationException("El email ya está registrado.");
            var hash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            var user = new UserRecord
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = hash,
                Role = "user"
            };
            _users.Add(user);
            return await Task.FromResult(GenerateToken(user));
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            var user = _users.Find(u => u.Email == dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                throw new InvalidOperationException("Credenciales inválidas.");
            return await Task.FromResult(GenerateToken(user));
        }

        private AuthResponseDto GenerateToken(UserRecord user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? "supersecretkey"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );
            return new AuthResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };
        }

        // Clase interna para simular usuario
        private class UserRecord
        {
            public string Name { get; set; } = null!;
            public string Email { get; set; } = null!;
            public string PasswordHash { get; set; } = null!;
            public string Role { get; set; } = null!;
        }
    }
} 