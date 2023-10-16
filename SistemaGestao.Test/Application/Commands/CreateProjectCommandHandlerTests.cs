using Moq;
using SistemaGestaoTcc.Application.Commands.Projects.CreateProject;
using SistemaGestaoTcc.Application.Commands.Users.CreateUser;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestao.Test.Application.Commands
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task DataOk_Executa_RetornaProjetoId()
        {
            //ARRANGE
            var projetoRepository = new Mock<IProjectRepository>();
            var userRepository = new Mock<IUsuarioProjetoRepository>();

            var createProjectCommand = new CreateProjectCommand
            {
                Nome = "Teste",
                Descricao = "descricao teste",
                IdCurso = 1,
                IdUsuario = 2
            };
            var createUserCommand = new CreateUserCommand
            {
                IdCurso = 1,
                Nome = "teste",
                Email = "Teste",
                Senha = "1231231",
                Papel = "Teste",
                Periodo = 5
            };

            //iniciando um commando handler
            var createProjectCommandHandler = new CreateProjectCommandHandler(projetoRepository.Object, userRepository.Object);
           
            /*retorna um ID de projeto*/
            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());
            //ACT

            //ASSERTS
            Assert.True(id >= 0);

            /*Checar se o metodo AddAsync foi chamado*/
            projetoRepository.Verify(pr => pr.AddASync(It.IsAny<Projeto>()), Times.Once);
        }
    }
}
