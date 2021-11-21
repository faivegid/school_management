using System.Threading.Tasks;
using GPA_Calculator.Core;
using GPA_Calculator.Data.Repositories;
using GPA_Calculator.Models.DomainModels;
using GPA_Calculator.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GPA_Calculator.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentRepository _studentRepository;


        public StudentController(ILogger<StudentController> logger, IStudentRepository studentRepository)
        {
            this._logger = logger;
            this._studentRepository = studentRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Index(string studentId)
        {
            var student = await _studentRepository.GetAsync(studentId);
            return View(student);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(StudentViewModel studentModel)
        {
            Student student = Mapper.MapToStudent(studentModel);
            await _studentRepository.CreateAsync(student);
            return LocalRedirect("/Home");
        }
       

        [HttpGet]
        public async Task<IActionResult> DetailsAsync(string studentId)
        {
            var student = await _studentRepository.GetAsync(studentId);
            return View(student);
        }


        [HttpPost]
        public IActionResult Edit()
        {
            return View();
        }


        public async Task<IActionResult> DeleteAsync(string studentId)
        {
            await _studentRepository.DeleteAsync(studentId);
            return LocalRedirect("/Home");
        }
    }
}
