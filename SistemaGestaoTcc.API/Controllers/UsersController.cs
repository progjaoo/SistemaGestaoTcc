using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTcc.Application.Commands.Users.CreateUser;
using SistemaGestaoTcc.Application.Commands.Users.LoginUser;
using SistemaGestaoTcc.Application.Commands.Users.UpdateUser;
using SistemaGestaoTcc.Application.Queries.Users.GetAllUserByRole;
using SistemaGestaoTcc.Application.Queries.Users.GetAllUsersByCourse;
using SistemaGestaoTcc.Application.Queries.Users.GetUser;
using SistemaGestaoTcc.Application.Queries.Users.GetUserByEmail;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;
using SistemaGestaoTcc.Infrastructure.Repositories;

namespace SistemaGestaoTcc.API.Controllers
{
    [Route("api/usuarios")]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;
        private readonly IEnvioImagemRepository _envioImagemRepository;

        public UsersController(IMediator mediator, IUserRepository userRepository, IEnvioImagemRepository envioImagemRepository)
        {
            _mediator = mediator;
            _userRepository = userRepository;
            _envioImagemRepository = envioImagemRepository;
        }

        [HttpGet("userByRole")]
        public async Task<IActionResult> GetAllByRole(string papel)
        {
            var getAllUserByRole = new GetAllUserByRoleQuery(papel);
            var listUsersRole = await _mediator.Send(getAllUserByRole);

            return Ok(listUsersRole);
        }
        [HttpGet("userByCourse")]
        public async Task<IActionResult> GetAllUserByCourse(int id)
        {
            var getAllByCourse = new GetAllByCourseQuery(id);

            var listUsers = await _mediator.Send(getAllByCourse);

            return Ok(listUsers);
        }
        [HttpGet("id")]
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
        [HttpGet("email")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var query = new GetUserByEmailQuery(email);

            var user = await _mediator.Send(query);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost("criarUsuario")]
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
                return Unauthorized();
            }
            return Ok(loginUserViewModel);
        }
        [HttpPut("atualizarUsuario")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserCommand command)
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
        [HttpPut("envioImagens")]
        public async Task<IActionResult> EnvioImagens(int idUsuario, IFormFile file)
        {
            try
            {
                var usuario = await _userRepository.GetById(idUsuario);
                if (usuario == null)
                {
                    return NotFound("Projeto não encontrado.");
                }
                if (file == null || file.Length == 0)
                {
                    return BadRequest("Nenhum arquivo enviado.");
                }
                string nomeArquivoBlob = $"Usuario-{idUsuario}-{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

                await _envioImagemRepository.UploadImage(file, nomeArquivoBlob);
                usuario.Imagem = nomeArquivoBlob;

                await _userRepository.SaveChangesAsync();

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
