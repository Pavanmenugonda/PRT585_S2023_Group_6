using Microsoft.AspNetCore.Mvc;

namespace Emai.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
