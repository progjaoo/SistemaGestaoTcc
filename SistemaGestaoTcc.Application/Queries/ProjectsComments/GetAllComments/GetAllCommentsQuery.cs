using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;

namespace SistemaGestaoTcc.Application.Queries.ProjectsComments.GetAllComments
{
    public class GetAllCommentsQuery : IRequest<List<ProjectCommentViewModel>>
    {
        public GetAllCommentsQuery(int idProjeto)
        {
            IdProjeto = idProjeto;
        }

        public int IdProjeto { get; set; }
    }
}
