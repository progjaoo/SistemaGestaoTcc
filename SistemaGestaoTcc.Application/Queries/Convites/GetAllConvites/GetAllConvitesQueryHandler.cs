using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Queries.Convites.GetAllConvites
{
    public class GetAllConvitesQueryHandler : IRequestHandler<GetAllConvitesQuery, List<ConviteViewModel>>
    {
        private readonly IConviteRepository _conviteRepository;
        public GetAllConvitesQueryHandler(IConviteRepository conviteRepository)
        {
            _conviteRepository = conviteRepository;
        }

        public async Task<List<ConviteViewModel>> Handle(GetAllConvitesQuery request, CancellationToken cancellationToken)
        {
            var convite = await _conviteRepository.GetAllAsync(request.Query);

            var conviteViewModel = convite
            .Select(c => new ConviteViewModel(c.Id, c.DataEnvio, c.DataExpira, c.Aceito)).ToList();

            return conviteViewModel;
        }
    }
}