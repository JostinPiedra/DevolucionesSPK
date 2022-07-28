using System.Web.Mvc;

namespace FrontEnd.Controllers.Procesos
{
    [Authorize]
    public class RecepcionController : Controller
    {
        // GET: Recepcion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tecnico()
        {
            return View();
        }

        public ActionResult Bodega()
        {
            return View();
        }
    }
}