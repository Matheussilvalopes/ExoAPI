using ExoAPI.Interfaces;
using ExoAPI.Models;
using ExoAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ExoAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository;
        public LoginController(IUsuarioRepository iUsuarioRepository)
        {
            _iUsuarioRepository = iUsuarioRepository;
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario usuarioBuscado = _iUsuarioRepository.Login(login.Email, login.Senha);
                if (usuarioBuscado == null)
                {
                    return Unauthorized(new { msg = "E-mail ou senha inválidos!" });
                }

                var minhasClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.Tipo)
                };

                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("exo-chave-autenticacao"));

                var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(

                    issuer:"ExoAPI",
                    audience:"ExoAPI",
                    claims:minhasClaims,
                    expires:DateTime.Now.AddMinutes(30),
                    signingCredentials:credenciais

                    );
                return Ok(new {token = new JwtSecurityTokenHandler().WriteToken(meuToken)});
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }
    }
}
