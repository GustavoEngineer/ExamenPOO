using CursosOnline.Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CursosOnline.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // Aquí deberías inyectar un AuthService real
        // private readonly AuthService _authService;
        // public AuthController(AuthService authService) { _authService = authService; }

        // POST: api/auth/register
        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            // Implementar lógica de registro y devolver JWT
            return Ok(new { message = "Registro exitoso (implementa lógica real)" });
        }

        // POST: api/auth/login
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            // Implementar lógica de login y devolver JWT
            return Ok(new { token = "jwt_token_ejemplo", name = "Usuario", email = dto.Email, role = "user" });
        }
    }
} 