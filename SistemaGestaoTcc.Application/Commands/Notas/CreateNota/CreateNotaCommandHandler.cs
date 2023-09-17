using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Commands.Notas.CreateNota
{
    public class CreateNotaCommandHandler : IRequestHandler<CreateNotaCommand, int>
    {
        private readonly INotaRepository _notaRepository;

        public CreateNotaCommandHandler(INotaRepository notaRepository)
        {
            _notaRepository = notaRepository;
        }

        public async Task<int> Handle(CreateNotaCommand request, CancellationToken cancellationToken)
        {
            var nota = new Nota(request.IdProjeto, request.IdUsuario, request.Valor);
            //project.ProjetoComentario.Add(new ProjetoComentario(request.IdUsuario, request.Id, "Projeto criado"));

            await _notaRepository.AddASync(nota);
            await _notaRepository.SaveChangesAsync();

            return nota.Id;
        }
    }
}