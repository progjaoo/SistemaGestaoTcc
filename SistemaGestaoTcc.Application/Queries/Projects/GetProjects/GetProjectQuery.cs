using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;

namespace SistemaGestaoTcc.Application.Queries.Projects.GetProjects
{
    public class GetProjectQuery : IRequest<List<ProjectViewModel>>
    {
        //public GetProjectQuery(string query)
        //{
        //    Query = query;
        //}

        public string Query { get; set; }
    }
}
