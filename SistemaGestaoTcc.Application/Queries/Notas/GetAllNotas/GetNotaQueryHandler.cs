using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Queries.Notas.GetAllNotas
{
    public class GetNotaQueryHandler : IRequestHandler<GetNotaQuery, List<NotaViewModel>>
    {
        private readonly INotaRepository _notaRepository;

        public GetNotaQueryHandler(INotaRepository notaRepository)
        {
            _notaRepository = notaRepository;
        }

        public async Task<List<NotaViewModel>> Handle(GetNotaQuery request, CancellationToken cancellationToken)
        {
            var notas = await _notaRepository.GetAllAsync(request.Query);

            var notaViewModels = notas
                .Select(p => new NotaViewModel(p.IdProjeto, p.IdUsuario, p.Valor)).ToList();

            return notaViewModels;
        }
    }
}