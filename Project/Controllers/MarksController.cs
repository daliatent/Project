using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.DTOs;
using Project.Services;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly MarksServices marksService;

        public MarksController(MarksServices marksService)
        {
            this.marksService = marksService;
        }

        [HttpPost("{studentId}/subject/{subjectId}")]
        public IActionResult AddMark(int studentId, int subjectId, [FromBody] int value)
        {
            marksService.AddMark(studentId, subjectId, value);
            return Ok();
        }

        [HttpGet("{studentId}")]
        public ActionResult<List<MarkToCreateDTo>> GetMarksByStudent(int studentId)
        {
            return Ok(marksService.GetMarksByStudent(studentId));
        }

        [HttpGet("{studentId}/subject/{subjectId}")]
        public ActionResult<List<MarkToCreateDTo>> GetMarksByStudentAndSubject(int studentId, int subjectId)
        {
            return Ok(marksService.GetMarksByStudentAndSubject(studentId, subjectId));
        }

        [HttpGet("{studentId}/subject/{subjectId}/average")]
        public ActionResult<double> GetAverageMarkByStudentAndSubject(int studentId, int subjectId)
        {
            return Ok(marksService.GetAverageMarkByStudentAndSubject(studentId, subjectId));
        }
    }
}
