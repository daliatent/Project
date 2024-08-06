using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.DTOs;
using Project.Services;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly SubjectsServices subjectsService;

        public SubjectsController(SubjectsServices subjectsService)
        {
            this.subjectsService = subjectsService;
        }

        [HttpPost]
        public ActionResult<SubjectToCreateDTo> AddSubject([FromBody] SubjectToCreateDTo subjectDTO)
        {
            var addedSubject = subjectsService.AddSubject(subjectDTO);
            return Ok(addedSubject);
        }

        [HttpGet]
        public ActionResult<List<SubjectToCreateDTo>> GetAllSubjects()
        {
            return Ok(subjectsService.GetAllSubjects());
        }
    }
}
