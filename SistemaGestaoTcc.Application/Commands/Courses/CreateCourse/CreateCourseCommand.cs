using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SistemaGestaoTcc.Application.Commands.Courses.CreateCourse
{
    public class CreateCourseCommand : IRequest<int>
    {
        public string Nome { get; set; }

        public int? Periodos { get; set; }
    }
}
