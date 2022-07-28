using System.Web.Mvc;

namespace FrontEnd.Controllers.Configuracion
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(string producto)
        {
            return View();
        }
    }
}