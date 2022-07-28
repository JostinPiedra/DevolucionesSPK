using Common;
using Model.Auth;
using Model.Custom;
using Persistence.DbContextScope;
using Persistence.DbContextScope.Extensions;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public interface IUsuarioService
    {
        /// <summary>
        /// Método que devuelve todos los registros
        /// </summary>
        /// <returns></returns>
        IEnumerable<UsuarioViewModel> GetAll();
        /// <summary>
        /// Método que devuelve un registro
        /// </summary>
        /// <param name="id">id del registro</param>
        /// <returns></returns>
        UsuarioViewModel GetUser(string id);
        /// <summary>
        /// Método que edita un registro
        /// </summary>
        /// <param name="model">entidad a editar</param>
        /// <returns></returns>
        ResponseHelper Edit(UsuarioViewModel model);
        /// <summary>
        /// Método que elimina el registro seleccionado
        /// </summary>
        /// <param name="id">id del registro</param>
        /// <returns></returns>
        ResponseHelper Delete(string id);
    }
    public class UsuarioService : IUsuarioService
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<ApplicationUser> _usuarioRepository;
        private readonly IRepository<ApplicationRole> _rolRepository;
        private readonly IRepository<ApplicationUserRole> _usuarioPorRolRepository;

        public UsuarioService(IDbContextScopeFactory dbContextScopeFactory,
            IRepository<ApplicationUser> usuarioRepository,
            IRepository<ApplicationRole> rolRepository,
            IRepository<ApplicationUserRole> usuarioPorRolRepository)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _usuarioRepository = usuarioRepository;
            _rolRepository = rolRepository;
            _usuarioPorRolRepository = usuarioPorRolRepository;
        }

        public IEnumerable<UsuarioViewModel> GetAll()
        {
            var resultado = new List<UsuarioViewModel>();

            try
            {
                using (var context = _dbContextScopeFactory.Create())
                {
                    var usuarios = context.GetEntity<ApplicationUser>();
                    var roles = context.GetEntity<ApplicationRole>();
                    var usuariosPorRoles = context.GetEntity<ApplicationUserRole>();

                    var usuarioPorRol = (
                        from a in usuariosPorRoles
                        from b in roles.Where(x => x.Id == a.RoleId)
                        select new
                        {
                            a.UserId,
                            b.Name
                        }).AsQueryable();

                    resultado = (from a in usuarios
                              select new UsuarioViewModel
                              {
                                  Id = a.Id,
                                  Nombre = a.UserName,
                                  Apellido = a.UserName,
                                  Email = a.UserName
                              }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return resultado;
        }
        #region CRUD Usuarios
        public UsuarioViewModel GetUser(string id)
        {
            var usuario = new UsuarioViewModel();

            try
            {
                using (var context = _dbContextScopeFactory.Create())
                {
                    var dbUser = context.GetEntity<ApplicationUser>().Where(x => x.Id == id).FirstOrDefault();
                    var dbUserRole = context.GetEntity<ApplicationUserRole>().Where(x => x.UserId == id).FirstOrDefault();
                    var dbRole = context.GetEntity<ApplicationRole>().Where(x => x.Id == dbUserRole.RoleId);

                    usuario.Id = dbUser.Id;
                    usuario.Nombre = dbUser.Nombre;
                    usuario.Apellido = dbUser.Apellido;
                    usuario.Email = dbUser.Email;
                    usuario.Rol = dbRole.FirstOrDefault().Name;
                    usuario.RolesList = context.GetEntity<ApplicationRole>().Select(x => new RoleViewModel { Id = x.Id, Name = x.Name }).ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }

            return usuario;
        }
        public ResponseHelper Edit(UsuarioViewModel model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var context = _dbContextScopeFactory.Create())
                {
                    var usuario = context.GetEntity<ApplicationUser>().Where(x => x.Id == model.Id).FirstOrDefault();

                    usuario.Nombre = model.Nombre;
                    usuario.Apellido = model.Apellido;
                    usuario.Email = model.Email;

                    _usuarioRepository.Update(usuario);
                    context.SaveChanges();
                    rh.Response = true;
                }
            }
            catch (Exception e)
            {
                rh.Response = false;
                throw;
            }

            return rh;
        }
        public ResponseHelper Delete(string id)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var context = _dbContextScopeFactory.Create())
                {
                    var usuario = context.GetEntity<ApplicationUser>().Where(x => x.Id == id).FirstOrDefault();
                    _usuarioRepository.Delete(usuario);
                    context.SaveChanges();
                    rh.Response = true;
                }
            }
            catch (Exception e)
            {
                rh.Response = false;
                throw;
            }

            return rh;
        }
        #endregion
    }
}
