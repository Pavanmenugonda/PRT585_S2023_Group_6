using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using BusinessEmail.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessEmail.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult Form(string receiverEmail, string subject, string message)
        {
            try {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("sanjubhujel2525@gmail.com");
                    var reciveremail = new MailAddress(receiverEmail,"Reveiver");
                    var password = "Bishnu@2sanju123";
                    var sub = subject;
                    var msg = message;

                    var smtp = new SmtpClient
                    {
                        Host="smtp.gmail.com",
                        Port=587,
                        EnableSsl=true,
                        DeliveryMethod=SmtpDeliveryMethod.Network,
                        UseDefaultCredentials=false,
                        Credentials=new NetworkCredential(senderEmail.Address,password)
                    };
                    using(var messge=new MailMessage(senderEmail, reciveremail)
                    {
                        Subject=subject,
                        Body=msg
                    }
                    )
                    {
                        smtp.Send(messge);
                    }
                    return View();

                }
            }
            catch (Exception)
            {
                ViewBag.Error = "There are some problem in send a mail";
            }

            return View();
        }

    }
}