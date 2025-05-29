using Microsoft.AspNetCore.Mvc;
using Api_University.Models;

namespace Api_University.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        [HttpGet("response")]
        public ActionResult<ResponseModel> GetResponse()
        {
            var response = new ResponseModel
            {
                Status = "Success",
                Message = "This is a sample response."
            };
            return Ok(response);
        }
    }
}