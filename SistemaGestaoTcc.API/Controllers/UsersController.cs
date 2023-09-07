using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTcc.Application.Commands.Users.CreateUser;
using SistemaGestaoTcc.Application.Commands.Users.LoginUser;
using SistemaGestaoTcc.Application.Commands.Users.UpdateUser;
using SistemaGestaoTcc.Application.Queries.Users.GetUser;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.API.Controllers
{
    [Route("api/users")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;
        public UsersController(IMediator mediator, IUserRepository userRepository)
        {
            _mediator = mediator;
            _userRepository = userRepository;
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
        public async Task<IActionResult> UpdateLogin(int id, [FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}/deleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);

            await _userRepository.SaveChangesAsync();

            return Ok();
        }
    }
}
