using Microsoft.AspNetCore.Mvc;
using my_mvc_api.Models;

namespace my_mvc_api.Controllers
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