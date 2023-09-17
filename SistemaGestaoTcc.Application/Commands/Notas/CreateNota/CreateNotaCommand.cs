using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace SistemaGestaoTcc.Application.Commands.Notas.CreateNota
{
    public class CreateNotaCommand : IRequest<int>
    {
        public int IdProjeto { get; set; }
        public int IdUsuario { get; set; }
        public int? Valor { get; set; }
    }
}