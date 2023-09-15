using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;

namespace SistemaGestaoTcc.Application.Queries.Users.GetAllByCourse
{
    public class GetAllByCourseCommand : IRequest<UserViewModel0>
    {
        public GetAllByCourseCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
