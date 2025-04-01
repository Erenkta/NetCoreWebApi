using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {

        [NonAction]
        public IActionResult CreateActionResult<T>(ServiceResult<T> result)
        {
            if (result.Status == System.Net.HttpStatusCode.NoContent)
            {
                return new ObjectResult(null) { StatusCode = result.Status.GetHashCode() };
            }
            return new ObjectResult(result) { StatusCode = result.Status.GetHashCode() };
        }

        [NonAction] // Swagger bunları bir endpoint olarak algılamasın
        public IActionResult CreateActionResult(ServiceResult result)
        {
            if (result.Status == System.Net.HttpStatusCode.NoContent)
            {
                return new ObjectResult(null) { StatusCode = result.Status.GetHashCode() };
            }
            return new ObjectResult(result) { StatusCode = result.Status.GetHashCode() };
        }
    }
}
