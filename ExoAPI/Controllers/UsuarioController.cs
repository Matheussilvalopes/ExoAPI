using ExoAPI.Interfaces;
using ExoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExoAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository;
        public UsuarioController(IUsuarioRepository iUsuarioRepository)
        {
            _iUsuarioRepository = iUsuarioRepository;

        }

        [HttpGet]
        public IActionResult ListarUsuarios()
        {
            try
            {
                return Ok(_iUsuarioRepository.Listar());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarUsuario(int id, Usuario usuario)
        {
            try
            {
                _iUsuarioRepository.Atualizar(id, usuario);
                return Ok("Usuário atualizado com sucesso!");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarUsuarioPorId(int id)
        {
            try
            {
                Usuario usuarioBuscado = _iUsuarioRepository.BuscaPorId(id);
                if (usuarioBuscado == null)
                {
                    return NotFound();
                }
                return Ok(usuarioBuscado);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpPost]
        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            try
            {
                _iUsuarioRepository.Cadastrar(usuario);
                return Ok("Usuário cadastrado com sucesso!");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            try
            {
                _iUsuarioRepository.Deletar(id);
                return Ok("Usuário deletado com sucesso!");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
