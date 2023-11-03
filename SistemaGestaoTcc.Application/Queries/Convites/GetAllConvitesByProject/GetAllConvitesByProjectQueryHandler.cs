using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Queries.Convites.GetAllConvitesByProject
{
    public class GetAllConvitesByProjectQueryHandler : IRequestHandler<GetAllConvitesQueryByProject, List<ConviteViewModel>>
    {
        private readonly IConviteRepository _conviteRepository;
        public GetAllConvitesByProjectQueryHandler(IConviteRepository conviteRepository)
        {
            _conviteRepository = conviteRepository;
        }

        public async Task<List<ConviteViewModel>> Handle(GetAllConvitesQueryByProject request, CancellationToken cancellationToken)
        {
            var convite = await _conviteRepository.GetAllByUserId(request.IdProjeto);

            var conviteViewModel = convite
            .Select(c => new ConviteViewModel(c.Id, c.IdProjeto, c.IdUsuario, 
            new Projeto(c.IdProjetoNavigation.IdCurso, c.IdProjetoNavigation.Nome, c.IdProjetoNavigation.Descricao),
            c.DataEnvio, c.DataExpira, c.Aceito)).ToList();

            return conviteViewModel;
        }
    }
}