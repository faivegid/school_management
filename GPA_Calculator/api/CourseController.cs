using GPA_Calculator.Core;
using GPA_Calculator.Data.Repositories;
using GPA_Calculator.Data.Repositories.Interfaces;
using GPA_Calculator.Models.DomainModels;
using GPA_Calculator.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPA_Calculator.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CourseController(ILogger<CourseController> logger, IUnitOfWork unitOfWork)
        {
            this._logger = logger;
            this._unitOfWork = unitOfWork;
        }


        [HttpGet]
        [Route("{courseId}")]
        public async Task<IActionResult> GetAsync(string courseId)
        {
            Course course = await _unitOfWork.CourseRepository.GetAsync(courseId);
            return Ok(course);
        }


        [HttpPut]
        [Route("create")]
        public async Task<IActionResult> CreateAsync(CourseViewModel courseModel)
        {
            Course course = Mapper.MapToCourse(courseModel);

            var student = await _unitOfWork.StudentRepository.GetAsync(courseModel.StudentId);
            course.Students = new List<Student>() {student };

            await _unitOfWork.CourseRepository.CreateAsync(course);
            var result = await _unitOfWork.SaveAllChangesAsync();

            return result ? StatusCode(StatusCodes.Status204NoContent) : StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
