using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;

namespace SistemaGestaoTcc.Application.Queries.Courses.GetAllCourse
{
    public class GetAllCoursesQuery : IRequest<List<CourseViewModel>>
    {
        public GetAllCoursesQuery()
        {
            
        }

        public string Query { get; set; }
    }
}
