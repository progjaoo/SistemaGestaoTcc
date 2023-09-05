using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Commands.ProjectComment.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Unit>
    {
        private readonly IProjectCommentRepository _projectCommentRepository;

        public UpdateCommentCommandHandler(IProjectCommentRepository projectCommentRepository)
        {
            _projectCommentRepository = projectCommentRepository;
        }

        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _projectCommentRepository.GetCommentById(request.Id);

            comment.UpdateComment(request.Conteudo);

            await _projectCommentRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
