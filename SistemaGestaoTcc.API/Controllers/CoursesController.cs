﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTcc.Application.Commands.Courses.CreateCourse;
using SistemaGestaoTcc.Application.Commands.Courses.UpdateCourse;
using SistemaGestaoTcc.Application.Commands.Projects.CreateProject;
using SistemaGestaoTcc.Application.Queries.Courses.GetAllCourse;
using SistemaGestaoTcc.Application.Queries.Courses.GetCourseById;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.API.Controllers
{
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICourseRepository _courseRepository;
        public CoursesController(IMediator mediator, ICourseRepository courseRepository)
        {
            _mediator = mediator;
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(string query)
        {
            var getAllCoursesQuery = new GetAllCoursesQuery(query);

            var course = await _mediator.Send(getAllCoursesQuery);

            return Ok(course);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new GetCoursesByIdQuery(id);

            var course = await _mediator.Send(query);

            if (course == null) 
            {
                return NotFound();
            }
            return Ok(course);
        }
        [HttpPost]
        public async Task<IActionResult> PostCourse([FromBody] CreateCourseCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = id }, command);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCourseCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _courseRepository.DeleteCourse(id);
            await _courseRepository.SaveChangesAsync();
            return Ok();
        }
        
    }
}