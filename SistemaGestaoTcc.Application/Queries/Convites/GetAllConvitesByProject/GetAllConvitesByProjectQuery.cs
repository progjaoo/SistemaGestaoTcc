using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;

namespace SistemaGestaoTcc.Application.Queries.Convites.GetAllConvitesByProject
{
    public class GetAllConvitesQueryByProject : IRequest<List<ConviteViewModel>>
    {
        public GetAllConvitesQueryByProject(int idProjeto)
        {
            IdProjeto = idProjeto;
        }
        public int IdProjeto { get; set; }

    }
}