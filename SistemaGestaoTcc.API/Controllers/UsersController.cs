using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTcc.Application.Commands.Users.CreateUser;
using SistemaGestaoTcc.Application.Commands.Users.LoginUser;
using SistemaGestaoTcc.Application.Commands.Users.UpdateUser;
using SistemaGestaoTcc.Application.Queries.Users.GetUser;

namespace SistemaGestaoTcc.API.Controllers
{
    [Route("api/users")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserQuery(id);

            var user = await _mediator.Send(query);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id  = id }, command);
        }

        [HttpPut("login")]
        [Authorize(Roles = "Professor")]
        [Authorize(Roles = "Aluno")]
        [AllowAnonymous]
        public async Task <IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginUserViewModel = await _mediator.Send(command);

            if(loginUserViewModel == null)
            {
                return BadRequest();
            }
            return Ok(loginUserViewModel);
        }
        [HttpPut("AtualizarLogin")]
        [Authorize(Roles = "Professor")]
        [Authorize(Roles = "Aluno")]
        public async Task<IActionResult> UpdateLogin(int id, [FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
