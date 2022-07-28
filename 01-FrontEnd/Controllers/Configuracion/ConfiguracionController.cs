using FrontEnd.CustomClass;
using System.Web.Mvc;

namespace FrontEnd.Controllers.Configuracion
{
    public class ConfiguracionController : Controller
    {
        [CustomAuthorize("Administrador")]
        // GET: Configuracion
        public ActionResult Index()
        {
            return View();
        }
    }
}