using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Queries.ProjectsComments
{
    public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, ProjectCommentViewModel>
    {
        private readonly IProjectRepository _projectRepository;

        public GetCommentQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ProjectCommentViewModel> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var comment = await _projectRepository.GetCommentById(request.Id);

            if (comment == null) return null;

            var commentViewModel = new ProjectCommentViewModel(
                comment.Id,
                comment.Conteudo,
                comment.CriadoEm);

            return commentViewModel;
        }
    }
}
