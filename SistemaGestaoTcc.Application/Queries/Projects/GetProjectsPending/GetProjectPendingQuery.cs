using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;

namespace SistemaGestaoTcc.Application.Queries.Projects.GetProjectsPending
{
    public class GetProjectPendingQuery : IRequest<List<ProjectViewModel>>
    {
        //public GetProjectQuery(string query)
        //{
        //    Query = query;
        //}

        public string Query { get; set; }
    }
}
