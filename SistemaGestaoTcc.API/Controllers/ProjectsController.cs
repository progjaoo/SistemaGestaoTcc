using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTcc.Application.Commands.ProjectComment.CreateComment;
using SistemaGestaoTcc.Application.Commands.ProjectComment.UpdateComment;
using SistemaGestaoTcc.Application.Commands.Projects.CreateProject;
using SistemaGestaoTcc.Application.Commands.Projects.DeleteProject;
using SistemaGestaoTcc.Application.Commands.Projects.UpdateProject;
using SistemaGestaoTcc.Application.Queries.Projects.GetProjectById;
using SistemaGestaoTcc.Application.Queries.Projects.GetProjects;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.API.Controllers
{
    [Route("api/projetos")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IProjectRepository _projectRepository;
        public ProjectsController(IMediator mediator, IProjectRepository projectRepository)
        {
            _mediator = mediator;
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAllProjectQuery = new GetProjectQuery();
            var projects = await _mediator.Send(getAllProjectQuery);

            return Ok(projects);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProjectByIdQuery(id);

            var project = await _mediator.Send(query);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }
        //[Authorize(Roles = "Aluno")]
        [HttpPost("criarProjeto")]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPut("{id}/atualizarComentario")]
        // [Authorize(Roles = "Aluno")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}/deletarProjeto")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
        [HttpPut("{id}/tornarPublico")]
        public async Task<IActionResult> TornarPublico(int id)
        {
            try
            {
                await _projectRepository.TornarPublico(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
