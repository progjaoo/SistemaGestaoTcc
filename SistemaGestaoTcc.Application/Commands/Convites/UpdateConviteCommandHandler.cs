using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Commands.Convites
{
    public class UpdateConviteCommandHandler : IRequestHandler<UpdateConviteCommand, Unit>
    {
        private readonly IConviteRepository _conviteRepository;

        public UpdateConviteCommandHandler(IConviteRepository conviteRepository)
        {
            _conviteRepository = conviteRepository;
        }

        public async Task<Unit> Handle(UpdateConviteCommand request, CancellationToken cancellationToken)
        {
            var convite = await _conviteRepository.GetById(request.Id);

            convite.Update(request.Aceito);

            await _conviteRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
