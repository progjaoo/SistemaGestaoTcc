using MediatR;
using SistemaGestaoTcc.Core.Enums;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Commands.Convites.EnviarConvite
{
    public class EnviarConviteCommandHandler : IRequestHandler<EnviarConviteCommand, int>
    {
        private readonly SistemaTccContext _dbcontext;

        public EnviarConviteCommandHandler(SistemaTccContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> Handle(EnviarConviteCommand request, CancellationToken cancellationToken)
        {
            // cria um convite
            var convidar = new Convite
            {
                IdUsuario = request.IdUsuario,
                IdProjeto = request.IdProjeto,
                DataEnvio = DateTime.Now,
                DataExpira = DateTime.Now.AddDays(7), // Defina uma data de expiração para o convite.
                Aceito = ConviteAceito.Pendente
            };

            _dbcontext.Convite.Add(convidar);

            await _dbcontext.SaveChangesAsync();

            return convidar.Id;

        }
    }
}
