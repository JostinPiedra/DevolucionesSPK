using FrontEnd.CustomClass;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model.Auth;
using Model.Custom;
using Persistence.DatabaseContext;
using System.Linq;
using System.Web.Mvc;

namespace FrontEnd.Controllers.Configuracion
{
    public class RoleController : Controller
    {
        #region Variables
        ApplicationDbContext context = new ApplicationDbContext();
        #endregion

        #region CRUD Roles
        [CustomAuthorize("Administrador")]
        // GET: Role
        public ActionResult Index()
        {
            //var model = _rolRepository.GetAll();
            var model = context.Roles.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RoleViewModel modelo)
        {
            var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));
            var role = new ApplicationRole
            {
                Name = modelo.Name
            };
            roleManager.Create(role);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            var role = context.ApplicationRole.Where(x => x.Id == id).FirstOrDefault();
            var modelo = new RoleViewModel()
            {
                Id = role.Id,
                Name = role.Name
            };
            return View(modelo);
        }

        [HttpPost]
        public ActionResult Edit(RoleViewModel modelo)
        {
            var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));
            var role = context.ApplicationRole.Where(x => x.Id == modelo.Id).FirstOrDefault();

            role.Name = modelo.Name;

            roleManager.Update(role);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));
            var role = context.ApplicationRole.Where(x => x.Id == id).FirstOrDefault();

            roleManager.Delete(role);

            return RedirectToAction("Index");
        }
        #endregion
    }
}