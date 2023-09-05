using Microsoft.AspNetCore.Mvc;

namespace SistemaGestaoTcc.API.Controllers
{
    public class CoursesController : ControllerBase
    {
        [Route("api/courses")]
        public MethodAccessException GetMethodAccessException() { return new MethodAccessException(); }
    }
}
