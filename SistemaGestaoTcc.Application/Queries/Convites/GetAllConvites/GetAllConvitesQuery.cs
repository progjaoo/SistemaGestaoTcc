using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;

namespace SistemaGestaoTcc.Application.Queries.Convites.GetAllConvites
{
    public class GetAllConvitesQuery : IRequest<List<ConviteViewModel>>
    {
        public GetAllConvitesQuery(int idUsuario)
        {
            IdUsuario = idUsuario;
        }
        public int IdUsuario { get; set; }

    }
}