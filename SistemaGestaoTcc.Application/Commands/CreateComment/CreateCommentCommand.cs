using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace SistemaGestaoTcc.Application.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<Unit>
    {
        public int IdUsuario { get; set; }

        public int IdProjeto { get; set; }

        public string Conteudo { get; set; }

    }
}