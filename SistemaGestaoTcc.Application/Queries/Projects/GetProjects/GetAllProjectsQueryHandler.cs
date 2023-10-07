using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using SistemaGestaoTcc.Application.ViewModels;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Queries.Projects.GetProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetProjectQuery, List<ProjectViewModel>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsQueryHandler(IProjectRepository projetoRepository)
        {
            _projectRepository = projetoRepository;
        }

        public async Task<List<ProjectViewModel>> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {

            var projeto = await _projectRepository.GetAllAsync();

            var projectViewModel = projeto
                .Select(p => new ProjectViewModel(p.Id, p.Nome, p.Descricao, p.DataInicio, p.Estado))
                .ToList();

            return projectViewModel;
        }
    }
}
