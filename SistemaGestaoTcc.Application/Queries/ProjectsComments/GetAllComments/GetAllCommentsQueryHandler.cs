using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Queries.ProjectsComments.GetAllComments
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, List<ProjectCommentViewModel>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllCommentsQueryHandler(IProjectRepository projetoRepository)
        {
            _projectRepository = projetoRepository;
        }
        public async Task<List<ProjectCommentViewModel>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var comment = await _projectRepository.GetAllCommentsAsync(request.Query);

            var commentViewModel = comment
                .Select(p => new ProjectCommentViewModel(p.Id, p.Conteudo, p.CriadoEm))
                .ToList();

            return commentViewModel;
        }
    }
}
