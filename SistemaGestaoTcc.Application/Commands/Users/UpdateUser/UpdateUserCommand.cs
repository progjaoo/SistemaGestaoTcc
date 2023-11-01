using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SistemaGestaoTcc.Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public int IdCurso { get; set; }

        public string Nome { get; set; }

        // public string Senha { get; set; }
    }
}
