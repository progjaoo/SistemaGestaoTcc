using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Commands.Notas.UpdateNota
{
    public class UpdateNotaCommandHandler : IRequestHandler<UpdateNotaCommand, Unit>
    {
        private readonly INotaRepository _notaRepository;

        public UpdateNotaCommandHandler(INotaRepository notaRepository)
        {
            _notaRepository = notaRepository;
        }

        public async Task<Unit> Handle(UpdateNotaCommand request, CancellationToken cancellationToken)
        {
            var nota = await _notaRepository.GetById(request.Id);

            nota.Update(request.Valor);

            return Unit.Value;
        }
    }
}