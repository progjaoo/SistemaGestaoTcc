using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;

namespace SistemaGestaoTcc.Application.Queries.Users.GetAllUserByRole
{
    public class GetAllUserByRoleQuery : IRequest<List<UserRoleViewModel>>
    {
        public GetAllUserByRoleQuery(string papel)
        {
            Papel = papel;
        }

        public string Papel { get; set; }
    }
}
