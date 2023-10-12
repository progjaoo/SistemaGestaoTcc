using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Infrastructure.Repositories;

namespace SistemaGestaoTcc.Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public UpdateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);

            var passwordHash = _authService.ComputeSha256Hash(request.Senha);

            user.Update(request.IdCurso, request.Nome, passwordHash);

            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
