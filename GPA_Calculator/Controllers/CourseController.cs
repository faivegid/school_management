using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GPA_Calculator.Core;
using GPA_Calculator.Data.Repositories;
using GPA_Calculator.Data.Repositories.Implementation;
using GPA_Calculator.Data.Repositories.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;

        public CourseController(ILogger<CourseController> logger, IUnitOfWork unitOfWork)
        {
            this._logger = logger;
            this._unitOfWork = unitOfWork;
        }

        public IActionResult Create(string studentId)
        {
            ViewBag.StudentId = studentId;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync(CourseViewModel courseModel)
        {
            var student = await _unitOfWork.StudentRepository.GetAsync(courseModel.StudentId);

            var course = Mapper.MapToCourse(courseModel);

            // assing the sudent which course is to be addes to
            course.Students = new List<Student>() { student };

            await _unitOfWork.CourseRepository.CreateAsync(course);
            return RedirectToAction("Details", "Student", new { studentId = courseModel.StudentId });
        }



        [HttpPost]
        public async Task<IActionResult> EditAsync(string courseId, CourseViewModel courseModel)
        {
            var course = Mapper.MapToCourse(courseModel);
            course.CourseId = courseId;
            _unitOfWork.CourseRepository.Edit(course);
            await _unitOfWork.SaveAllChangesAsync();
            return RedirectToAction("Details", "Student", new { studentId = courseModel.StudentId}); ;
        }


        public async Task<IActionResult> DeleteAsync(string courseId)
        {
            var studentId = HttpContext.Session.GetString("studentId");
            Course course = await _unitOfWork.CourseRepository.GetAsync(studentId);
            if (course != null)
            {
                 _unitOfWork.CourseRepository.Delete(course);
                if(await _unitOfWork.SaveAllChangesAsync())
                {
                    return RedirectToAction("Details", "Student", new { studentId = studentId }); 
                }
            }
            return RedirectToAction();
        }
    }
}
