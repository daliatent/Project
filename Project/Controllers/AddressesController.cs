using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Services;

namespace Project.Controllers
{
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

    }
}
