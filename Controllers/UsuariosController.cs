using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ProjetoAliLeo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAliLeo.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoAliLeo.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEventoRepository _eventoRepository;

        private readonly IConfiguration _configuration;

           [HttpPost]
        public IActionResult Cadastrar([FromBody] Usuario usuario)
        {
            _usuarioRepository.Cadastrar(usuario);
            return Created("", usuario);
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
           Usuario? usuarioExixtente = _usuarioRepository.BuscarUsuarioPorEmailSenha(usuario.Email, usuario.Senha);

            if (usuarioExixtente == null)
            {
                return Unauthorized(new {Mensagem = "Usuario ou senha Invalidos!"});
            }

            String token = GerarToken(usuarioExixtente);
            return Ok(token);
            

            
        }

        [HttpGet("listar")]

        [Authorize]
         public IActionResult Listar()
        {

            return Ok(_usuarioRepository.Listar());
        }

        [ApiExplorerSettings(IgnoreApi = true)]
          public string GerarToken(Usuario usuario)
        {
            var claims = new []
            {
                new Claim(ClaimTypes.Name, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Permissao.ToString())
            };

            var chave = Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]!);

            var assinatura = new SigningCredentials(
                new SymmetricSecurityKey(chave),
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(5),
                signingCredentials: assinatura
               
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
