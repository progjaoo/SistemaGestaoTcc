using MediatR;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly SistemaTccContext _dbcontext;
        private readonly IAuthService _authService;
        public CreateUserCommandHandler(SistemaTccContext dbcontext, IAuthService authService)
        {
            _dbcontext = dbcontext;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Senha);
            //instancia do novo usuario pediu 2 construtores la na classe 
            var user = new Usuario(request.IdCurso, request.Nome, request.Email, passwordHash, request.Papel, request.Periodo);

            await _dbcontext.Usuario.AddAsync(user);
            await _dbcontext.SaveChangesAsync();

            return user.Id;
        }
    }
}
