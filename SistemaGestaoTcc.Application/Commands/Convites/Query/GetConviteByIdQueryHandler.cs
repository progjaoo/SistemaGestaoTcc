using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Commands.Convites.Query
{
    public class GetConviteByIdQueryHandler : IRequestHandler<GetConviteById, ConviteViewModel>
    {
        private readonly IConviteRepository _conviteRepository;

        public GetConviteByIdQueryHandler(IConviteRepository conviteRepository)
        {
            _conviteRepository = conviteRepository;
        }

        public async Task<ConviteViewModel> Handle(GetConviteById request, CancellationToken cancellationToken)
        {
            var convite = await _conviteRepository.GetById(request.Id);

            if (convite == null) return null;

            var conviteViewModel = new ConviteViewModel(
                   convite.Id,
                   convite.DataEnvio,
                   convite.DataExpira,
                   convite.Aceito);

            return conviteViewModel;
        }
    }
}
