using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;

namespace SistemaGestaoTcc.Application.Queries.Notas.GetByIdNotas
{
    public class GetNotaByIdQuery : IRequest<NotaViewModel>
    {
        public GetNotaByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}