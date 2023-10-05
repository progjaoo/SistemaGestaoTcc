using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;
using SistemaGestaoTcc.Core.Interfaces;

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

            var conviteViewModel = new ConviteViewModel(convite.Id, convite.DataEnvio, convite.DataExpira, convite.Aceito);

            return conviteViewModel;
        }
    }
}