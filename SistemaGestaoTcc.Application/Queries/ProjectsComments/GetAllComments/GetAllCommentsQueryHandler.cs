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
        private readonly IProjectCommentRepository _projectCommentRepository;

        public GetAllCommentsQueryHandler(IProjectCommentRepository projectCommentRepository)
        {
            _projectCommentRepository = projectCommentRepository;
        }
        public async Task<List<ProjectCommentViewModel>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var comment = await _projectCommentRepository.GetAllCommentsByProjectAsync(request.IdProjeto);

            var commentViewModel = comment
                .Select(p => new ProjectCommentViewModel(p.Id, p.IdUsuario, 
                new UserViewModel(p.IdUsuarioNavigation.Nome, p.IdUsuarioNavigation.Email, p.IdUsuarioNavigation.IdCurso),
                p.Conteudo, p.CriadoEm))
                .ToList();

            return commentViewModel;
        }
    }
}
