using SistemaGestaoTcc.Core.Enums;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestao.Test.Core
{

    public class ProjectTests
    {
        [Fact]
        public void TesteInicioProjetoFunciona()
        {
            //arrange
            var project = new Projeto(3, "Nome teste", "Descricao de testes");

            Assert.NotNull(project.Nome);
            Assert.NotEmpty(project.Nome);

            Assert.NotNull(project.Descricao);
            Assert.NotEmpty(project.Descricao);

            project.Start();

            Assert.Equal(StatusProjeto.InProgress, project.Estado);
            Assert.NotNull(project.DataInicio);
        }
    }
}
