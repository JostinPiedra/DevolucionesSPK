using Common;
using Model.Custom;
using Persistence.DatabaseContext;
using Service;
using System;
using System.Linq;
using System.Web.Mvc;

namespace FrontEnd.Controllers.Configuracion
{
    [Authorize]
    public class UsuariosController : Controller
    {
        #region Variables
        private readonly IUsuarioService _usuarioService = DependecyFactory.GetInstance<IUsuarioService>();
        ApplicationDbContext context = new ApplicationDbContext();
        #endregion

        #region CRUD Usuarios

        // GET: Usuarios
        public ActionResult Index()
        {
            var model = _usuarioService.GetAll();
            
            return View(model);
        }

        public ActionResult Edit(string id)
        {
            var modelo = _usuarioService.GetUser(id);
            ViewBag.Role = modelo.Rol;
            return View(modelo);
        }

        [HttpPost]
        public ActionResult Edit(UsuarioViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _usuarioService.Edit(modelo);
                    if (result.Response)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(modelo);
                    }
                }
                catch (Exception e)
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

        public ActionResult Delete(string id)
        {
            var result = _usuarioService.Delete(id);
            if (result.Response)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        #endregion
    }
}