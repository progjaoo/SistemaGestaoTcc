using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SistemaGestaoTcc.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Papel { get; set; }
    }
}
