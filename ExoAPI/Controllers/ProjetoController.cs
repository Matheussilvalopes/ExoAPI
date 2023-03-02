using ExoAPI.Interfaces;
using ExoAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExoAPI.Controllers
{
    [Produces("application/json") ]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoRepository _iProjetoRepository;
        public ProjetoController(IProjetoRepository iProjetoRepository)
        {
            _iProjetoRepository = iProjetoRepository;
        }

        [HttpGet]
        public IActionResult ListarProjetos()
        {
            try
            {
                return Ok(_iProjetoRepository.Listar());
;            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        // [Authorize(Roles ="Admin")]
        public IActionResult CadastrarProjeto(Projeto projeto)
        {
            try
            {
                _iProjetoRepository.Cadastrar(projeto);
                return Ok("Projeto cadastrado com sucesso!");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles ="Admin")]
        public IActionResult DeletarProjeto(int id)
        {
            try
            {
                _iProjetoRepository.Deletar(id);
                return Ok("Projeto deletado com sucesso!");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarProjeto(int id, Projeto projeto)
        {
            try
            {
                _iProjetoRepository.Atualizar(id, projeto);
                return StatusCode(204);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarProjetoPorId(int id)
        {
            try
            {
                Projeto projetoBuscado = _iProjetoRepository.BuscaPorId(id);
                if (projetoBuscado == null)
                {
                    return NotFound();
                }
                return Ok(projetoBuscado);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
