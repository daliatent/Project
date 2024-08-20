using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.DTOs;
using Project.Exceptions;
using Project.Services;

namespace Project.Controllers
{
    /// <summary>
    /// Controller pentru gestionarea adreselor.
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly StudentsServices studentsServices;
        private readonly AddressesService addressesService;
        public AddressesController(StudentsServices studentsServices, AddressesService addressesService)
        {
            this.studentsServices = studentsServices;
            this.addressesService = addressesService;
        }
        /// <summary>
        /// Adaugă un student la o adresă specifică.
        /// </summary>
        /// <param name="addressId">ID-ul adresei.</param>
        /// <param name="studentToCreate">Detaliile studentului de creat.</param>
        /// <param name="createIfNotExist">Flag pentru a crea studentul dacă nu există.</param>
        /// <returns>Un mesaj care indică rezultatul operației.</returns>
        [HttpPost("add-student-to-add/{addressId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AddressToCreateDTo>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public IActionResult AddStudentToAddress(int addressId, [FromBody] StudentToCreateDTO studentToCreate, [FromQuery] bool createIfNotExist = true)
        {
            if (addressId <= 0 || studentToCreate == null)
            {
                return BadRequest(new { Message = "Invalid input data." });
            }
            try
            {
                var address = addressesService.GetAddressByStudentId(addressId);
                if (address == null)
                {
                    return NotFound(new { Message = "Address not found." });
                }

                var studentEntity = studentsServices.GetStudentByName(studentToCreate.Name);
                if (studentEntity == null)
                {
                    if (!createIfNotExist)
                    {
                        return NotFound(new { Message = "Student not found and creation is disabled." });
                    }
                    studentEntity = studentsServices.AddStudent(studentToCreate.Name, studentToCreate.Surname, studentToCreate.Age);
                }

                addressesService.ChangeStudent(addressId, studentEntity.Id);
                return Ok(new { Message = "Student successfully added to address." });
            }
            catch (StudentIdNotExistException ex)
            {
                // Log the exception if necessary
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred.", Details = ex.Message });
            }
        }
     
    }
}
