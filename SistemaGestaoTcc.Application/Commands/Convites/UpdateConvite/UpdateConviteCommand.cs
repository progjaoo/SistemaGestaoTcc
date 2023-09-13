﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SistemaGestaoTcc.Application.Commands.Convites.UpdateConvite
{
    public class UpdateConviteCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public bool Aceito { get; set; }
    }
}