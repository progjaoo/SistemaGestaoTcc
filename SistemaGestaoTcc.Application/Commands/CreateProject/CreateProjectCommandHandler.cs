using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository;
        public CreateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Projeto(request.Nome, request.Descricao, request.Publicado, request.Aprovado, request.IdUsuarioNavigation);
            project.ProjetoComentario.Add(new ProjetoComentario("Projeto esta criado", request.IdProjetoNavigation ,request.IdUsuarioNavigation));
            await _projectRepository.AddASync(project);

            return project.Id;
        }
    }
}
