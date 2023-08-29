using System.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTcc.Application.Commands.CreateProject;
using SistemaGestaoTcc.Application.Queries.GetProjectById;
using SistemaGestaoTcc.Application.Queries.GetProjects;

namespace SistemaGestaoTcc.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(GetProjectQuery getProjectsQuery)
        {
            var projects = await _mediator.Send(getProjectsQuery);

            return Ok(projects);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProjectByIdQuery(id);

            var project = await _mediator.Send(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        //{
        //    var id = await _mediator.Send(command);
        //    return CreatedAtAction(nameof(GetById), new { id = id }, command);
        ////}
        ////[HttpPut("{id}")]
        ////[Authorize(Roles = "Aluno")]
        ////public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        ////{
        ////    await _mediator.Send(command);

        ////    return NoContent();
        ////}

    }
}
