using Common;
using Model.Custom;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers.Procesos
{
    public class SolicitudController : Controller
    {
        #region Variables
        private readonly ISolicitudService _solicitudService = DependecyFactory.GetInstance<ISolicitudService>();
        #endregion
        #region CRUD

        // GET: Solicitud
        public ActionResult Index()
        {
            var modelo = _solicitudService.GetAll();
            return View(modelo);
        }

        public ActionResult Details(int id)
        {
            var modelo = _solicitudService.GetSolicitud(id);
            return View(modelo);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SolicitudViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _solicitudService.Create(modelo);
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
            var modelo = _solicitudService.GetSolicitud(id);
            if (modelo.FechaSolicitud == null)
            {
                ViewBag.FechaSolicitud = modelo.FechaSolicitud;
            }
            else
            {
                ViewBag.FechaSolicitud = modelo.FechaSolicitud.Value.ToString("yyyy-MM-dd");
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
        public ActionResult Edit(SolicitudViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _solicitudService.Edit(modelo);
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
            var result = _solicitudService.Delete(id);

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