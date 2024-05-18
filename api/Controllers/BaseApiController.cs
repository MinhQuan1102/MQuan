using api.DTOModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        [NonAction]
        public ActionResult BaseResult(ApiResponse? data = null)
        {
            if (data == null)
            {
                return Ok();
            }

            switch(data.Status)
            {
                case (int)HttpStatusCode.OK:
                    return Ok(data);
                case (int)HttpStatusCode.Unauthorized:
                    return Unauthorized(data);
                case (int)HttpStatusCode.BadRequest:
                    return BadRequest(data);
                case (int)HttpStatusCode.NotFound:
                    return NotFound(data);
                default:
                    return StatusCode(data.Status, data);
            }
        }
    }
}
