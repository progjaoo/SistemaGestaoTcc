using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SistemaGestaoTcc.Application.Commands.Convites
{
    public class EnviarConviteCommand : IRequest<int>
    {
        public int Id { get; set; }

        public int IdUsuario { get; set; }

        public int IdProjeto { get; set; }

    }
}
