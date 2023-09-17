using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTcc.Application.Commands.ProjectComment.CreateComment;
using SistemaGestaoTcc.Application.Commands.ProjectComment.UpdateComment;
using SistemaGestaoTcc.Application.Queries.Projects.GetProjects;
using SistemaGestaoTcc.Application.Queries.ProjectsComments.GetAllComments;
using SistemaGestaoTcc.Application.Queries.ProjectsComments.GetCommentById;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.API.Controllers
{
    [Route("api/projetoComentarios")]
    public class ProjectCommentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IProjectCommentRepository _projectCommentRepository;
        public ProjectCommentController(IMediator mediator, IProjectCommentRepository projectCommentRepository)
        {
            _mediator = mediator;
            _projectCommentRepository = projectCommentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(string query)
        {
            var getAllCommentsQuery = new GetAllCommentsQuery(query);
            var comments = await _mediator.Send(getAllCommentsQuery);

            return Ok(comments);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var query = new GetCommentQuery(id);

            var comment = await _mediator.Send(query);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }
        [HttpPost("{id}/criarComentario")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}/deletarComentario")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _projectCommentRepository.DeleteComment(id);

            await _projectCommentRepository.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}/UpdateComement")]
        public async Task<IActionResult> UpdateComment(int id, [FromBody] UpdateCommentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
