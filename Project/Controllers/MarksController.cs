using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.DTOs;
using Project.Services;

namespace Project.Controllers
{
    /// <summary>
    /// Controller pentru gestionarea notelor.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly MarksServices marksService;

        public MarksController(MarksServices marksService)
        {
            this.marksService = marksService;
        }

        /// <summary>
        /// Adaugă o notă unui student pentru un anumit curs.
        /// </summary>
        /// <param name="studentId">ID-ul studentului.</param>
        /// <param name="subjectId">ID-ul cursului.</param>
        /// <param name="value">Nota obținută.</param>
        /// <returns>Statusul operației.</returns>
        [HttpPost("{studentId}/subject/{subjectId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MarkToCreateDTo>))]
        public IActionResult AddMark(int studentId, int subjectId, [FromBody] int value)
        {
            marksService.AddMark(studentId, subjectId, value);
            return Ok();
        }

        /// <summary>
        /// Obține notele unui student.
        /// </summary>
        /// <param name="studentId">ID-ul studentului.</param>
        /// <returns>O listă de note ale studentului.</returns>
        [HttpGet("{studentId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MarkToCreateDTo>))]
        public IActionResult GetMarksByStudent(int studentId)
        {
            return Ok(marksService.GetMarksByStudent(studentId));
        }

        /// <summary>
        /// Obține notele unui student pentru un anumit curs.
        /// </summary>
        /// <param name="studentId">ID-ul studentului.</param>
        /// <param name="subjectId">ID-ul cursului.</param>
        /// <returns>O listă de note ale studentului pentru cursul specificat.</returns>
        [HttpGet("{studentId}/subject/{subjectId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MarkToCreateDTo>))]
        public IActionResult GetMarksByStudentAndSubject(int studentId, int subjectId)
        {
            return Ok(marksService.GetMarksByStudentAndSubject(studentId, subjectId));
        }

        /// <summary>
        /// Obține media notelor unui student pentru un anumit curs.
        /// </summary>
        /// <param name="studentId">ID-ul studentului.</param>
        /// <param name="subjectId">ID-ul cursului.</param>
        /// <returns>Media notelor studentului pentru cursul specificat.</returns>
        [HttpGet("{studentId}/subject/{subjectId}/average")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MarkToCreateDTo>))]
        public IActionResult GetAverageMarkByStudentAndSubject(int studentId, int subjectId)
        {
            return Ok(marksService.GetAverageMarkByStudentAndSubject(studentId, subjectId));
        }
       
    }
}
