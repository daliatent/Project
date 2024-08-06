using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.DTOs;
using Project.Models;
using Project.Services;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsServices studentsServices;
        public StudentsController(StudentsServices studentsServices)
        {
            this.studentsServices = studentsServices;
        }
        [HttpGet]
        public ActionResult<List<StudentToCreateDTO>> GetAllStudents()
        {
            var students = studentsServices.GetAllStudents();
            if (students == null || !students.Any())
            {
                return NotFound();
            }
            return Ok(students);
        }
        
    }
}
