
using Microsoft.AspNetCore.Mvc;
using TarefasAPI.Models;
using TarefasAPI.Services;
using BCrypt.Net;
using TarefasAPI.DTOs;

namespace TarefasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly LoginService _loginService;

        public AuthController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto login)
        {
            var token = _loginService.Authenticate(login);
            

            if (token == null)
            {
                return StatusCode(500, "Ocorreu um erro na Authenticate!"); // Retorna um erro genérico para o cliente
            }
            else
            {
                             
                return StatusCode(200, $"Login realizado com sucesso! Token: {token}"); // Retorna uma mensagem de sucesso para o cliente
            }
            
        }
    }
}