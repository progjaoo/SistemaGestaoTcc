using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;

namespace SistemaGestaoTcc.Application.Queries.Projects.GetProjectsByUser
{
    public class GetProjectByUserQuery : IRequest<List<ProjectViewModel>>
    {
        public GetProjectByUserQuery(int idUsuario)
        {
           IdUsuario = idUsuario;
        }

        public int IdUsuario { get; set; }
    }
}
