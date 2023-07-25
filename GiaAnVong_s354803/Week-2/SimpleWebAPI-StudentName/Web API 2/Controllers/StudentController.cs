using Microsoft.AspNetCore.Mvc;

namespace Web_API_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController: ControllerBase
    {
        [HttpGet(Name = "GetStudentName")]
        public string GetStudentName()
        {
            return "Student name 1111";
        }
    }
}
