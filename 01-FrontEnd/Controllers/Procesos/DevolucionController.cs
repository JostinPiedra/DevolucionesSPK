using Common;
using Model.Custom;
using Service;
using System;
using System.Web.Mvc;

namespace FrontEnd.Controllers.Procesos
{
    [Authorize]
    public class DevolucionController : Controller
    {
        #region Variables
        private readonly IDevolucionService _devolucionService = DependecyFactory.GetInstance<IDevolucionService>();
        #endregion

        #region CRUD Devolucion
        // GET: Devolucion
        public ActionResult Index()
        {
            var modelo = _devolucionService.GetAll();

            return View(modelo);
        }

        public ActionResult Details(int id)
        {
            var modelo = _devolucionService.GetDevolucion(id);
            return View(modelo);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DevolucionViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _devolucionService.Create(modelo);
                    if (result.Response)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(modelo);
                    }
                }
                catch (Exception)
                {
                    return View();
                    throw;
                }
            }
            else
            {
                return View(modelo);
            }
        }

        public ActionResult Edit(int id)
        {
            var modelo = _devolucionService.GetDevolucion(id);
            if (modelo.FechaIngreso == null)
            {
                ViewBag.FechaIngreso = modelo.FechaIngreso;
            }
            else
            {
                ViewBag.FechaIngreso = modelo.FechaIngreso.Value.ToString("yyyy-MM-dd");
            }
            if (modelo.FechaFactura == null)
            {
                ViewBag.FechaFactura = modelo.FechaFactura;
            }
            else
            {
                ViewBag.FechaFactura = modelo.FechaFactura.Value.ToString("yyyy-MM-dd");
            }

            return View(modelo);
        }

        [HttpPost]
        public ActionResult Edit(DevolucionViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _devolucionService.Edit(modelo);
                    if (result.Response)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(modelo);
                    }
                }
                catch (Exception)
                {
                    return View();
                    throw;
                }
            }
            else
            {
                return View(modelo);
            }
        }

        public ActionResult Delete(int id)
        {
            var result = _devolucionService.Delete(id);

            if (result.Response)
            {
                return RedirectToAction("Index");
            }
            else
            {
                //Agregar vista de errores
                return View();
            }
        }

        #endregion
    }
}