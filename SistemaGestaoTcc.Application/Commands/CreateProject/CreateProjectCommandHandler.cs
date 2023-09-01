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
            var project = new Projeto(request.Nome, request.Descricao);
            //project.ProjetoComentario.Add(new ProjetoComentario(request.IdUsuario, request.Id, "Projeto criado"));

            await _projectRepository.AddASync(project);
            await _projectRepository.SaveChangesAsync();

            return project.Id;
        }
    }
}
