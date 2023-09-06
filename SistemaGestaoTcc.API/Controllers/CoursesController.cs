using Microsoft.AspNetCore.Mvc;

namespace SistemaGestaoTcc.API.Controllers
{
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult Get()
        {
            return NoContent();
        }
    }
}