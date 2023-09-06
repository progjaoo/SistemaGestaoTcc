using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;

namespace SistemaGestaoTcc.Application.Queries.Courses.GetCourseById
{
    public class GetCoursesByIdQuery : IRequest<CourseViewModel>
    {
        public GetCoursesByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}