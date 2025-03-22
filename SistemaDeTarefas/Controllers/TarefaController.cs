using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaRepositorio _tarefarepositorio;

        public TarefaController(ITarefaRepositorio tarefaRepositorio) 
        {
            _tarefarepositorio = (TarefaRepositorio?) tarefaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> GetAllTarefas() 
        {
            List<TarefaModel> tarefas = await _tarefarepositorio.BuscarTodasTarefas();
            return Ok(tarefas);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<TarefaModel>>> GetAllIds(int id)
        {
            TarefaModel tarefa = await _tarefarepositorio.BuscarPorId(id);
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] TarefaModel tarefaModel) 
        {
            TarefaModel tarefa = await _tarefarepositorio.Adicionar(tarefaModel);
            return Ok(tarefa);
        }

        [HttpPut]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] TarefaModel tarefaModel, int id)
        {
            tarefaModel.Id = id;
            TarefaModel tarefa = await _tarefarepositorio.Atualizar(tarefaModel, id);
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Boolean>> Apagar(int id)
        {
            bool apagado = await _tarefarepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
