using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<int>
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }

        public virtual Projeto IdProjetoNavigation { get; set; }

        public bool? Publicado { get; set; }

        public bool? Aprovado { get; set; }

        public int? Estado { get; private set; }

    }
}
