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
using SistemaGestaoTcc.Application.Queries.Projects.GetProjectsPending;
using SistemaGestaoTcc.Application.Queries.Projects.GetProjectsByUser;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;
using SistemaGestaoTcc.Infrastructure.Repositories;

namespace SistemaGestaoTcc.API.Controllers
{
    [Route("api/projetos")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IProjectRepository _projectRepository;
        private readonly IEnvioImagemRepository _envioImagemRepository;

        public ProjectsController(IMediator mediator, IProjectRepository projectRepository, IEnvioImagemRepository envioImagemRepository)
        {
            _mediator = mediator;
            _projectRepository = projectRepository;
            _envioImagemRepository = envioImagemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAllProjectQuery = new GetProjectQuery();
            var projects = await _mediator.Send(getAllProjectQuery);

            return Ok(projects);
        }
        [HttpGet("pendente")]
        public async Task<IActionResult> GetAllPendingAsync()
        {
            var getAllProjectQuery = new GetProjectPendingQuery();
            var projects = await _mediator.Send(getAllProjectQuery);

            return Ok(projects);
        }
        [HttpGet("porUsuario/{id}")]
        public async Task<IActionResult> GetAllByUserAsync(int id)
        {
            var getAllProjectQuery = new GetProjectByUserQuery(id);
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
        [HttpPut("atualizarProjeto")]
        // [Authorize(Roles = "Aluno")]
        public async Task<IActionResult> Put([FromBody] UpdateProjectCommand command)
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
        [HttpPut("envioImagens")]
        public async Task <IActionResult> EnvioImagens(int idProjeto, IFormFile file)
        {
            try
            {
                var projeto = await _projectRepository.GetById(idProjeto);
                if (projeto == null)
                {
                    return NotFound("Projeto não encontrado.");
                }
                if (file == null || file.Length == 0)
                {
                    return BadRequest("Nenhum arquivo enviado.");
                }
                string nomeArquivoBlob = $"Projeto-{idProjeto}-{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

                await _envioImagemRepository.UploadImage(file, nomeArquivoBlob);

                projeto.Imagem = nomeArquivoBlob;

                await _projectRepository.SaveChangesAsync();

                await _envioImagemRepository.SaveChangesAsync();

                return Ok("Arquivo enviado com sucesso.");
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    var innerExceptionMessage = ex.InnerException.Message;
                    Console.WriteLine($"Exceção interna: {innerExceptionMessage}");
                }

                Console.WriteLine($"Erro ao salvar as alterações no banco de dados: {ex.Message}");
                return BadRequest($"Ocorreu um erro ao enviar o arquivo: {ex.Message}");
            }
        }
    }
}
