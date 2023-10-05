using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using SistemaGestaoTcc.Core.Enums;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestao.Test.Core
{
    
    public class ProjectTests
    {
        [Fact]
        public void TesteInicioProjetoFunciona()
        {
            var project = new Projeto("Nome teste", "Descricao de testes");

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
