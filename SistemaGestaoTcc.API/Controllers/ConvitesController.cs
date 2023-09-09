using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using SistemaGestaoTcc.Application.Commands.Convites;
using SistemaGestaoTcc.Application.Services;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

[ApiController]
[Route("api/convites")]
public class ConvitesController : ControllerBase
{

    private readonly SistemaTccContext _dbcontext;
    private readonly IMediator _mediator;
    private readonly IUsuarioProjetoRepository _usuarioProjetoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProjectRepository _projectRepository;
    public ConvitesController(SistemaTccContext dbcontext, IMediator mediator, IUsuarioProjetoRepository usuarioProjetoRepository, IUserRepository userRepository, IProjectRepository projectRepository)
    {
        _dbcontext = dbcontext;
        _mediator = mediator;
        _usuarioProjetoRepository = usuarioProjetoRepository;
        _userRepository = userRepository;
        _projectRepository = projectRepository;
    }

    [HttpPost]
    public async Task<IActionResult> EnviarConvite([FromBody] EnviarConviteCommand command)
    {
        var project = await _projectRepository.GetById(command.IdProjeto);
        var user = await _userRepository.GetById(command.IdUsuario);

        var id = await _mediator.Send(command);
        EmailService emailService = new EmailService();

        var assunto = $"Convite para o Projeto";

        var content = $"<p>Olá {user.Nome}, Você recebeu um convite para participar do projeto {project.Nome}.<p/>";

        if (user.Papel == "professor")
        {
            content = $"<p>Olá Professor {user.Nome}, Você recebeu um convite para participar do projeto {project.Nome}.<p/>";
        }
        var htmlContent = content + $"<br><strong>Você recebeu um convite para participar do projeto. Clique <a href='https://pages.github.com/gilbertolgs/SistemaTCC-FrontEnd/convites'>aqui</a> para aceitar.</strong>";

        var email = new EmailAddress(user.Email);

        await emailService.ConviteEmailAsync(email, assunto, content, htmlContent);

        return CreatedAtAction(nameof(command), new { id = id }, command);
    }

    [HttpPut("aceitarConvite")]
    public async Task<IActionResult> AceitarConvite(int id)
    {
        var invite = await _dbcontext.Convite.FindAsync(id);

        if (invite == null)
        {
            return NotFound("Convite não encontrado.");
        }
        if (invite.Aceito == true)
        {
            return BadRequest("Este convite já foi aceito.");
        }
        if (invite.Aceito == false)
        {
            return BadRequest("Este convite já foi rejeitado.");
        }
        invite.Aceito = true;
        _dbcontext.Entry(invite).State = EntityState.Modified;

        await _dbcontext.SaveChangesAsync();

        return Ok("Convite aceito com sucesso!");
    }
    [HttpPut("rejeitarConvite")]
    public async Task<IActionResult> RejeitarConvite(int id)
    {
        var invite = await _dbcontext.Convite.FindAsync(id);

        if (invite == null)
        {
            return NotFound("Convite não encontrado.");
        }
        if (invite.Aceito == true)
        {
            return BadRequest("Este convite já foi aceito.");
        }
        if (invite.Aceito == false)
        {
            return BadRequest("Este convite já foi rejeitado.");
        }
        invite.Aceito = false;
        _dbcontext.Entry(invite).State = EntityState.Modified;

        await _dbcontext.SaveChangesAsync();

        return Ok("Convite rejeitado com sucesso!");
    }
}