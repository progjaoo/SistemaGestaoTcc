using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Queries.Convites
{
    public class GetByIdConviteQueryHandler : IRequestHandler<GetByIdConviteQuery, ConviteViewModel>
    {
        private readonly IConviteRepository _conviteRepository;
        public GetByIdConviteQueryHandler(IConviteRepository conviteRepository)
        {
            _conviteRepository = conviteRepository;
        }

        public async Task<ConviteViewModel> Handle(GetByIdConviteQuery request, CancellationToken cancellationToken)
        {
            var convite = await _conviteRepository.GetById(request.Id);

            if (convite == null) return null;

            var conviteViewModel = new ConviteViewModel(convite.Id, convite.IdProjeto, convite.IdUsuario,
            new Projeto(convite.IdProjetoNavigation.IdCurso, convite.IdProjetoNavigation.Nome, convite.IdProjetoNavigation.Descricao), 
            convite.DataEnvio, convite.DataExpira, convite.Aceito);

            return conviteViewModel;
        }
    }
}