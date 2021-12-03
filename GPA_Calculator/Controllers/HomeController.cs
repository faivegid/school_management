using GPA_Calculator.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GPA_Calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;


        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this._unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var students = await _unitOfWork.StudentRepository.GetAsync();
            return View(students);
        }// end IndexAsync
    }
}
