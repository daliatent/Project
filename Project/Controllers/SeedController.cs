using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using Project.Services;

namespace Project.Controllers
{
    /// <summary>
    /// Controller pentru seed-ul bazei de date.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly StudentsServices studentsServices;
        private readonly SeedServices seedServices;
        public SeedController(SeedServices seedServices)
        {
            this.seedServices = seedServices;
        }

        /// <summary>
        /// Populează baza de date cu date inițiale.
        /// </summary>
        [HttpPost]
        public void Seed()
        {
            this.seedServices.Seed();   
        }
    }
}
