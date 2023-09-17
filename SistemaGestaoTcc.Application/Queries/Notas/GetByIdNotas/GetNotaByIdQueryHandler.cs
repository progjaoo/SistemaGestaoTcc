using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Queries.Notas.GetByIdNotas
{
    public class GetNotaByIdQueryHandler : IRequestHandler<GetNotaByIdQuery, NotaViewModel>
    {
        private readonly INotaRepository _notaRepository;

        public GetNotaByIdQueryHandler(INotaRepository notaRepository)
        {
            _notaRepository = notaRepository;
        }
        public async Task<NotaViewModel> Handle(GetNotaByIdQuery request, CancellationToken cancellationToken)
        {
            var notas = await _notaRepository.GetById(request.Id);

            if (notas == null) return null;

            var notasViewModel = new NotaViewModel(
                    notas.IdProjeto,
                    notas.IdUsuario,
                    notas.Valor
            );
            return notasViewModel;
        }
    }
}