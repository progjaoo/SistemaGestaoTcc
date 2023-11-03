using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;

namespace SistemaGestaoTcc.Application.Queries.Users.FindUsers
{
    public class FindUsersQuery : IRequest<List<UserRoleViewModel>>
    {
        public FindUsersQuery()
        {
            Papel = "Aluno";
            Nome = "";
        }
        public FindUsersQuery(string papel, string nome)
        {
            Papel = papel;
            Nome = nome;
        }

        public string Papel { get; set; }
        public string Nome { get; set; }
    }
}
