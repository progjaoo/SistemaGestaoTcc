﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SistemaGestaoTcc.Application.Commands.ProjectComment.UpdateComment
{
    public class UpdateCommentCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public string Conteudo { get; set; }
    }
}
