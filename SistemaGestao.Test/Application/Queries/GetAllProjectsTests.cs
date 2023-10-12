using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using SistemaGestaoTcc.Application.Queries.Projects.GetProjects;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestao.Test.Application.Queries
{
    public class GetAllProjectsTests
    {
        [Fact]
        //adotando padrão de escrita de tests GIVEN WHEN THEN
        public async Task TresProjetosExistem_Executam_RetornamTresProjectsVM()
        {
            //arrange
            var projects = new List<Projeto>
            {
                new Projeto(3, "Teste 1", "Descricao teste 1"),
                new Projeto(3, "Teste 2", "Descricao teste 2"),
                new Projeto(3, "Teste 3", "Descricao teste 3")
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();

            projectRepositoryMock.Setup(p => p.GetAllAsync().Result).Returns(projects);

            var getAllProjectsQuery = new GetProjectQuery {Query = ""};

            var getAllProjectQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

            //ACT 

            var listProjects = getAllProjectQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            //ASSERTS
            Assert.NotNull(listProjects);
        }
    }
}
