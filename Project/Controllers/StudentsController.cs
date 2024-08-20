using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.DTOs;
using Project.Models;
using Project.Services;

namespace Project.Controllers
{
    /// <summary>
    /// Controller pentru gestionarea studenților.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsServices studentsServices;
        public StudentsController(StudentsServices studentsServices)
        {
            this.studentsServices = studentsServices;
        }

        /// <summary>
        /// Adaugă un student nou.
        /// </summary>
        /// <param name="studentToCreate">Detaliile studentului de creat.</param>
        /// <returns>Detaliile studentului creat.</returns>
        [HttpPost]
        public Student AddStudent([FromBody] StudentToCreateDTO studentToCreate) =>
            studentsServices.AddStudent(studentToCreate.Name, studentToCreate.Surname, studentToCreate.Age);

        /// <summary>
        /// Obține toți studenții.
        /// </summary>
        /// <returns>O listă cu toți studenții.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<StudentToCreateDTO>))]
        public IActionResult GetAllStudents()
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
