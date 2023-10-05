using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
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
            var projects = new List<Projeto>
            {
                new Projeto("Teste 1", "Descricao teste 1"),
                new Projeto("Teste 2", "Descricao teste 2"),
                new Projeto("Teste 3", "Descricao teste 3")
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
        }
    }
}
