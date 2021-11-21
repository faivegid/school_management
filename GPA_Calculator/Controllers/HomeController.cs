using System.Linq;
using System.Threading.Tasks;
using GPA_Calculator.Core;
using GPA_Calculator.Data;
using GPA_Calculator.Data.Repositories;
using GPA_Calculator.Models;
using GPA_Calculator.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GPA_Calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentRepository _studentRepository;


        public HomeController(ILogger<HomeController> logger, IStudentRepository studentRepository)
        {
            _logger = logger;
            this._studentRepository = studentRepository;
        }


        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var students = await _studentRepository.GetAsync();
            return View(students);
        }

    }
}
