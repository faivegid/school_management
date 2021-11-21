using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GPA_Calculator.Core;
using GPA_Calculator.Data.Repositories;
using GPA_Calculator.Models.DomainModels;
using GPA_Calculator.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GPA_Calculator.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public CourseController(ILogger<CourseController> logger, IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            this._logger = logger;
            this._studentRepository = studentRepository;
            this._courseRepository = courseRepository;
        }

        public IActionResult Create(string studentId)
        {
            HttpContext.Session.SetString("studentId", studentId);
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync(CourseViewmodel courseModel)
        {
            // Gets the student for which the course is being added to
            var studentId = HttpContext.Session.GetString("studentId");
            
            var student = await _studentRepository.GetAsync(studentId);

            var course = Mapper.MapToCourse(courseModel);

            // assing the sudent which course is to be addes to
            course.Students = new List<Student>() { student };

            await _courseRepository.CreateAsync(course);
            return RedirectToAction("Details", "Student", new { studentId = studentId });
        }



        [HttpPost]
        public async Task<IActionResult> EditAsync(string courseId, CourseViewmodel courseModel)
        {

            var studentId = HttpContext.Session.GetString("studentId");
            var course = Mapper.MapToCourse(courseModel);
            course.CourseId = courseId;
            await _courseRepository.EditAsync(course);
            return RedirectToAction("Details", "Student", new { studentId = studentId }); ;
        }


        public async Task<IActionResult> DeleteAsync(string courseId)
        {
            var studentId = HttpContext.Session.GetString("studentId");
            await _courseRepository.DeleteAsync(courseId);
            return RedirectToAction("Details", "Student", new { studentId = studentId }); ;
        }
    }
}
