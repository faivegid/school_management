using System.Threading.Tasks;
using GPA_Calculator.Core;
using GPA_Calculator.Data.Repositories;
using GPA_Calculator.Data.Repositories.Interfaces;
using GPA_Calculator.Models.DomainModels;
using GPA_Calculator.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GPA_Calculator.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IUnitOfWork _unitOfWork;


        public StudentController(ILogger<StudentController> logger, IUnitOfWork unitOfWork)
        {
            this._logger = logger;
            this._unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> IndexAsync(string studentId)
        {
            HttpContext.Session.SetString("studentId", studentId);
            var student = await _unitOfWork.StudentRepository.GetWithCourse(studentId);
            if(student == null)
            {
                LocalRedirect("home/error");
            }
            return View("Details", student);
        }// end IndexAsync


        public async Task<IActionResult> DeleteAsync(string studentId)
        {
            var student = await _unitOfWork.StudentRepository.GetAsync(studentId);
            if (student != null)
            {
                _unitOfWork.StudentRepository.Delete(student);
                await _unitOfWork.SaveAllChangesAsync();
            }
            return LocalRedirect("/Home");
        }// end DeleteAsync
    }
}
