using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTcc.Application.Commands.Notas.CreateNota;
using SistemaGestaoTcc.Application.Commands.Notas.UpdateNota;
using SistemaGestaoTcc.Application.Commands.Projects.CreateProject;
using SistemaGestaoTcc.Application.Commands.Projects.DeleteProject;
using SistemaGestaoTcc.Application.Commands.Projects.UpdateProject;
using SistemaGestaoTcc.Application.Queries.Notas.GetAllNotas;
using SistemaGestaoTcc.Application.Queries.Notas.GetByIdNotas;
using SistemaGestaoTcc.Application.Queries.Projects.GetProjectById;
using SistemaGestaoTcc.Application.Queries.Projects.GetProjects;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.API.Controllers
{
    [Route("api/notas")]
    [ApiController]
    public class NotaController : ControllerBase
    {
        private readonly INotaRepository _notaRepository;
        private readonly IMediator _mediator;
        public NotaController(INotaRepository notaRepository, IMediator mediator)
        {
            _notaRepository = notaRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(string query)
        {
            var getAllNotas = new GetNotaQuery(query);

            var notas = await _mediator.Send(getAllNotas);

            return Ok(notas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetNotaByIdQuery(id);

            var nota = await _mediator.Send(query);

            if (nota == null)
            {
                return NotFound();
            }

            return Ok(nota);
        }

        [HttpPost("lançarNotas")]
        public async Task<IActionResult> Post([FromBody] CreateNotaCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}/atualizar")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateNotaCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}/deletarNota")]
        public async Task<IActionResult> DeleteNota(int id)
        {
            await _notaRepository.DeleteNota(id);

            await _notaRepository.SaveChangesAsync();

            return Ok();
        }
    }
}
