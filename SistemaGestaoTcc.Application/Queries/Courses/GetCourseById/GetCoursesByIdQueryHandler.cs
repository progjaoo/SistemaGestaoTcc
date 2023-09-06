using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Queries.Courses.GetCourseById
{
    public class GetCoursesByIdQueryHandler : IRequestHandler<GetCoursesByIdQuery, CourseViewModel>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCoursesByIdQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<CourseViewModel> Handle(GetCoursesByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetById(request.Id);

            if (course == null) return null;

            var courseViewModel = new CourseViewModel(
                course.Id,
                course.Nome,
                course.Periodos
            );
            return courseViewModel;
        }

    }
}