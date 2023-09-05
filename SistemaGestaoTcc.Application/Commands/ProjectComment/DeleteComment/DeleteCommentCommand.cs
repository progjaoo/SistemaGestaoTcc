using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SistemaGestaoTcc.Application.Commands.ProjectComment.DeleteComment
{
    public class DeleteCommentCommand : IRequest<Unit>
    {
        public DeleteCommentCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
