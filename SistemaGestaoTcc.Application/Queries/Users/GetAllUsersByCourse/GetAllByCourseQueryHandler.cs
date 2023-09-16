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
    public class GetAllByCourseQueryHandler : IRequestHandler<GetAllByCourseQuery, List<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllByCourseQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserViewModel>> Handle(GetAllByCourseQuery request, CancellationToken cancellationToken)
        {
            var listUser = await _userRepository.GetAllUserByCourse(request.Query);

            var listUserViewModel = listUser
                .Select(p => new UserViewModel(p.Nome, p.Email, p.IdCurso)).ToList();

            return listUserViewModel;
        }
    }
}
