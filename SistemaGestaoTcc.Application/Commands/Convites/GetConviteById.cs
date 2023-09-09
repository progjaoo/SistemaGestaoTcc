using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;

namespace SistemaGestaoTcc.Application.Commands.Convites
{
    public class GetConviteById : IRequest<ConviteViewModel>
    {
        public GetConviteById(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
