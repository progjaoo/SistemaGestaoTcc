using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using MediatR;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Commands.ProjectComment.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly IProjectCommentRepository _projectCommentRepository;
        public CreateCommentCommandHandler(IProjectCommentRepository projecCommenttRepository)
        {
            _projectCommentRepository = projecCommenttRepository;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjetoComentario(request.IdProjeto, request.IdUsuario, request.Conteudo);

            await _projectCommentRepository.AddCommentAsync(comment);

            return Unit.Value;
        }
    }
}