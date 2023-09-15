using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Queries.Users.GetAllByCourse
{
    public class GetAllByCourseCommandHandler : IRequestHandler<GetAllByCourseCommand, UserViewModel>
    {
        private readonly IUserRepository _userRepository;

        public GetAllByCourseCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> Handle(GetAllByCourseCommand request, CancellationToken cancellationToken)
        {
            var listUser = await _userRepository.GetAllUserByCourse(request.Id);

            if (listUser == null) return null;

            var userViewModel = new UserViewModel(
                    listUser);

            return userViewModel;
        }
    }
}
