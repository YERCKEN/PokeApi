using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PokeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class nameController : ControllerBase
    {
        // Este método responderá a peticiones GET en "api/name"
        [HttpGet]
        public IActionResult Get()
        {
            // Devuelve el nombre estático "edwar"
            return Ok("edwar");
        }
    }

}
