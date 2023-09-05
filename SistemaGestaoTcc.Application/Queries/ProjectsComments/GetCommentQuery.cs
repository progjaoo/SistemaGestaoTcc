using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;

namespace SistemaGestaoTcc.Application.Queries.ProjectsComments
{
    public class GetCommentQuery : IRequest<ProjectCommentViewModel>
    {
        public GetCommentQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
