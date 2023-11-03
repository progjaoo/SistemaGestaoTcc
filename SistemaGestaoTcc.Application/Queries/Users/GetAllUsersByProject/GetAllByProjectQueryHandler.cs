using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;
using SistemaGestaoTcc.Infrastructure.Repositories;

namespace SistemaGestaoTcc.Application.Queries.Users.GetAllUsersByCourse
{
    public class GetAllByProjectQueryHandler : IRequestHandler<GetAllByProjectQuery, List<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUsuarioProjetoRepository _usuarioProjetoRepository;

        public GetAllByProjectQueryHandler(IUserRepository userRepository, IUsuarioProjetoRepository usuarioProjetoRepository)
        {
            _userRepository = userRepository;
            _usuarioProjetoRepository = usuarioProjetoRepository;
        }

        public async Task<List<UserViewModel>> Handle(GetAllByProjectQuery request, CancellationToken cancellationToken)
        {
            var listUser = await _usuarioProjetoRepository.GetAllByProjectId(request.Query);

            var listUserViewModel = listUser
                .Select(p => new UserViewModel(p.Id, p.Nome, p.Email, p.IdCurso, p.Papel)).ToList();

            return listUserViewModel;
        }
    }
}
