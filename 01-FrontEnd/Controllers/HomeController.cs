using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            if (User.IsInRole("Administrador"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Test");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}