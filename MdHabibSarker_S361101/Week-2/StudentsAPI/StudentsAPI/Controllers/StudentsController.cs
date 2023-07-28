using Microsoft.AspNetCore.Mvc;

namespace StudentsAPI.Controllers
{
    public class StudentsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
