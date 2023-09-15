using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Core.Enums;

namespace SistemaGestaoTcc.Application.Commands.Convites.UpdateConvite
{
    public class UpdateConviteCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public ConviteAceito Aceito { get; set; }
    }
}
