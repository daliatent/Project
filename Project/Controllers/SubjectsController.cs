using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.DTOs;
using Project.Services;

namespace Project.Controllers
{
    /// <summary>
    /// Controller pentru gestionarea cursurilor.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly SubjectsServices subjectsService;

        public SubjectsController(SubjectsServices subjectsService)
        {
            this.subjectsService = subjectsService;
        }

        /// <summary>
        /// Adaugă un curs nou.
        /// </summary>
        /// <param name="subjectDTO">Detaliile cursului de creat.</param>
        /// <returns>Detaliile cursului adăugat.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SubjectToCreateDTo>))]
        public IActionResult AddSubject([FromBody] SubjectToCreateDTo subjectDTO)
        {
            if (subjectDTO == null || string.IsNullOrWhiteSpace(subjectDTO.Name))
            {
                return BadRequest(new { Message = "Invalid subject data." });
            }

            var addedSubject = subjectsService.AddSubject(subjectDTO);
            return Ok(addedSubject);
        }

        /// <summary>
        /// Obține toate cursurile.
        /// </summary>
        /// <returns>Lista cursurilor existente.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SubjectToCreateDTo>))]
        public IActionResult GetAllSubjects()
        {
            return Ok(subjectsService.GetAllSubjects());
        }
        /// <summary>
        /// Șterge un curs după ID.
        /// </summary>
        /// <param name="id">ID-ul cursului de șters.</param>
        /// <returns>Statusul operației.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteSubject(int id)
        {
            var subject = subjectsService.GetSubjectById(id);
            if (subject == null)
            {
                return NotFound(new { Message = "Subject not found." });
            }

            subjectsService.DeleteSubject(id);
            return Ok(new { Message = "Subject successfully deleted." });
        }

        /// <summary>
        /// Actualizează detaliile unui curs.
        /// </summary>
        /// <param name="id">ID-ul cursului de actualizat.</param>
        /// <param name="subjectDTO">Noile detalii ale cursului.</param>
        /// <returns>Statusul operației.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateSubject(int id, [FromBody] SubjectToCreateDTo subjectDTO)
        {
            if (subjectDTO == null || id <= 0 || string.IsNullOrWhiteSpace(subjectDTO.Name))
            {
                return BadRequest(new { Message = "Invalid subject data." });
            }

            var subject = subjectsService.GetSubjectById(id);
            if (subject == null)
            {
                return NotFound(new { Message = "Subject not found." });
            }

            subjectsService.UpdateSubject(id, subjectDTO);
            return Ok(new { Message = "Subject successfully updated." });
        }
    }
}
