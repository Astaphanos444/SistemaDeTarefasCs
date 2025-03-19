using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepositorio _usuariorepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio) 
        {
            _usuariorepositorio = (UsuarioRepositorio?)usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> GetAllUsers() 
        {
            List<UsuarioModel> usuarios = await _usuariorepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<UsuarioModel>>> GetAllIds(int id)
        {
            UsuarioModel usuarios = await _usuariorepositorio.BuscarPorId(id);
            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuario) 
        {
            UsuarioModel usuario = await _usuariorepositorio.Adicionar(usuario);
            return Ok(usuario);
        }

        [HttpPut]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuario, int id)
        {
            usuario.Id = id;
            UsuarioModel usuario = await _usuariorepositorio.Atualizar(usuario, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Boolean>> Apagar(int id)
        {
            bool apagado = await _usuariorepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
