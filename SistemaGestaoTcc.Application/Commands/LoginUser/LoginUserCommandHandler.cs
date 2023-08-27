using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            //usando o o algoritmo 256 para criar o hash da senha
            var passwordHash = _authService.ComputeSha256Hash(request.Senha);

            //busca no banco de dados o user com o email e senha em formato hash
            var user = await _userRepository.GetByEmailByPassword(request.Email, passwordHash);

            //se nao tem da erro
            if(user == null)
            {
                return null;
            }

            //se existir, gera o tokendo usando os dados do cara
            var token = _authService.GenerateJwtToken(user.Email, user.Papel);

            return new LoginUserViewModel(user.Email, token);   
        }
    }
}
