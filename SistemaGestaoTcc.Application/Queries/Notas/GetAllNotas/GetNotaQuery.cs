﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;

namespace SistemaGestaoTcc.Application.Queries.Notas.GetAllNotas
{
    public class GetNotaQuery : IRequest<List<NotaViewModel>>
    {
        public GetNotaQuery(string query)
        {
            Query = query;
        }

        public string Query { get; set; }
    }
}
