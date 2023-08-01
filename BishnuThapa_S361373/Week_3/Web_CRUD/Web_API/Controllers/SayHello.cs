using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_API_tut_1.Controllers
{
    [Route("api/hello")]
    [ApiController]
    public class SayHello : ControllerBase
    {
        [HttpGet]
        public String getSayHello()
        {
            return "Hello guys";
        }
        [HttpPost] public String postSayHello() { return "Post is done"; }
       
    }
}
