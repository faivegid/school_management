using GPA_Calculator.Core;
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
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IUnitOfWork _unitOfWork;


        public StudentController(ILogger<StudentController> logger, IUnitOfWork unitOfWork)
        {
            this._logger = logger;
            this._unitOfWork = unitOfWork;
        }


        [HttpPut]
        [Route("create")]
        public async Task<ActionResult> CreateAsync(StudentViewModel studentModel)
        {
            Student student = Mapper.MapToStudent(studentModel);
            await _unitOfWork.StudentRepository.CreateAsync(student);

            var result = await _unitOfWork.SaveAllChangesAsync();

            if (result) return StatusCode(StatusCodes.Status204NoContent);            
            return BadRequest();
        }


        [HttpGet]
        [Route("{studentId}")]
        public async Task<ActionResult> GetAsync(string studentId)
        {
            Student student = await _unitOfWork.StudentRepository.GetAsync(studentId);
            if(student != null) return StatusCode(StatusCodes.Status200OK, student);
             
            return BadRequest("No student with the given Id");            
        }


        [HttpPatch]
        [Route("edit")]
        public async Task<ActionResult> EditAsync(Student student)
        {
            _unitOfWork.StudentRepository.Edit(student);
            var result = await _unitOfWork.SaveAllChangesAsync();

            return result ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status400BadRequest);
        }

    }
}
