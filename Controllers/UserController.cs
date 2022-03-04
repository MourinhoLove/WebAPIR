using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Use.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet]
        public ActionResult getDishes([FromQuery] int count)
        {
            string[] dishes = { "A", "B", "C" };
            if (!dishes.Any()) {
                return NotFound();
            }
            return Ok(dishes.Take(count));
        }
        [HttpDelete("all")]
        public ActionResult DeleteUser() {
            return NoContent();
        }

    }

}
