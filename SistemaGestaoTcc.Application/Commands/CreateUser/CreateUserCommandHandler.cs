using MediatR;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Commands.CreateUser
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
            var user = new Usuario(request.Nome, request.Email, request.Papel, request.Papel, passwordHash);

            await _dbcontext.Usuario.AddAsync(user);
            await _dbcontext.SaveChangesAsync();

            return user.Id;
        }
    }
}
