﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using SistemaGestaoTcc.Application.Commands.Convites.EnviarConvite;
using SistemaGestaoTcc.Application.Commands.Convites.UpdateConvite;
using SistemaGestaoTcc.Application.Services;
using SistemaGestaoTcc.Core.Enums;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;
using SistemaGestaoTcc.Infrastructure.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


[ApiController]
[Route("api/convites")]
public class ConvitesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IConviteRepository _conviteRepository;
    private readonly IUsuarioProjetoRepository _usuarioProjetoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProjectRepository _projectRepository;
    public ConvitesController(IConviteRepository conviteRepository, IMediator mediator, IUsuarioProjetoRepository usuarioProjetoRepository, IUserRepository userRepository, IProjectRepository projectRepository)
    {
        _mediator = mediator;
        _conviteRepository = conviteRepository;
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

        var linkEndereco = "https://gilbertolgs.github.io/SistemaTCC-FrontEnd/convites";
        var conteudo = $"{user.Nome}, você recebeu um convite para participar do projeto {project.Nome}.";
        var botaoNome = "Ir para o Projeto";

        var email = new EmailAddress(user.Email);

        await emailService.ConviteEmailAsync(email, assunto, linkEndereco, conteudo, botaoNome);

        return CreatedAtAction(nameof(command), new { id = id }, command);
    }

    [HttpPut("aceitarConvite")]
    public async Task<IActionResult> AceitarConvite(int id ,[FromBody] UpdateConviteCommand command)
    {
        var invite = await _conviteRepository.GetById(id);

        if (invite == null)
        {
            return NotFound("Convite não encontrado.");
        }
        if (invite.Aceito == ConviteAceito.Aceito) 
        {
            return BadRequest("Este convite já foi aceito.");
        }
        if (invite.Aceito == ConviteAceito.Recusado)
        {
            return BadRequest("Este convite já foi rejeitado.");
        }
        invite.Aceito = ConviteAceito.Aceito;

        await _mediator.Send(command);
        return Ok("Convite aceito com sucesso!");

    }
    [HttpPut("rejeitarConvite")]
    public async Task<IActionResult> RejeitarConvite(int id, [FromBody] UpdateConviteCommand command)
    {
        var invite = await _conviteRepository.GetById(id);

        if (invite == null)
        {
            return NotFound("Convite não encontrado.");
        }
        if (invite.Aceito == ConviteAceito.Aceito)
        {
            return BadRequest("Este convite já foi aceito.");
        }
        if (invite.Aceito == ConviteAceito.Recusado)
        {
            return BadRequest("Este convite já foi rejeitado.");
        }
        invite.Aceito = ConviteAceito.Recusado;
        await _mediator.Send(command);
        return Ok("Convite rejeitado com sucesso!");
    }
}