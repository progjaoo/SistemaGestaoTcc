using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace SistemaGestaoTcc.Application.Commands.Notas.UpdateNota
{
    public class UpdateNotaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int? Valor { get; set; }
    }
}