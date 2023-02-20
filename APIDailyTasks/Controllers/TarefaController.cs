using APIDailyTasks.Models;
using APIGerenciadorTarefas.Data;
using APIGerenciadorTarefas.Data.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIGerenciadorTarefas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private TarefaContext _context;
        private IMapper _mapper;
        public TarefaController(TarefaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AdicionaTarefa([FromBody] CreateTarefaDto tarefaDto)
        {
            Tarefa tarefa = _mapper.Map<Tarefa>(tarefaDto);
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaTarefaPorId), 
                new {id = tarefa.Id}, tarefa);
        }
        [HttpGet]
        public IEnumerable<ReadTarefaDto> RecuperaTarefa()
        {
            return _mapper.Map<List<ReadTarefaDto>>(_context.Tarefas);
        }
        [HttpGet("{id}")]
        public IActionResult RecuperaTarefaPorId(int id)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(tarefa => tarefa.Id == id);
            if (tarefa == null) return NotFound();
            var tarefaDto = _mapper.Map<ReadTarefaDto>(tarefa);
            return Ok(tarefaDto);

        }
        [HttpGet("naofinalizada")]
        public IEnumerable<ReadTarefaDto> RecuperaTarefaNaoFinalizada()
        {
            return _mapper.Map<List<ReadTarefaDto>>(_context.Tarefas.Where(tarefa => !tarefa.Finalizado));
        }
        [HttpGet("finalizada")]
        public IEnumerable<ReadTarefaDto> RecuperaTarefaFinalizada()
        {
            return _mapper.Map<List<ReadTarefaDto>>(_context.Tarefas.Where(tarefa => tarefa.Finalizado));
        }
        [HttpPut("{id}")]
        public IActionResult AtualizaTarefa(int id, [FromBody] UpdateTarefaDto tarefaDto)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(tarefa => tarefa.Id == id);
            if(tarefa == null) return NotFound();
            _mapper.Map(tarefaDto, tarefa);
            _context.SaveChanges();
            return NoContent();

        }
        [HttpDelete("{id}")]
        public IActionResult DeletaTarefa(int id)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(tarefa => tarefa.Id == id);
            if(tarefa == null) return NotFound();
            _context.Remove(tarefa);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
