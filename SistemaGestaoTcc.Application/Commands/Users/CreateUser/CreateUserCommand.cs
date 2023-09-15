using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MediatR;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Commands.Users.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public int IdCurso { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Papel { get; set; }

        public int? Periodo { get; set; }

    }
}
