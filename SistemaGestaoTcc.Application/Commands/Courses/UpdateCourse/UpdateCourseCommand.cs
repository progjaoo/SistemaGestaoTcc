using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SistemaGestaoTcc.Application.Commands.Courses.UpdateCourse
{
    public class UpdateCourseCommand : IRequest<Unit> 
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int? Periodos { get; set; }
    }
}
