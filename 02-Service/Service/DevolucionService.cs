using Common;
using Model.Custom;
using Model.Domain;
using Persistence.DbContextScope;
using Persistence.DbContextScope.Extensions;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public interface IDevolucionService
    {
        /// <summary>
        /// Método que devuelve todos los registros
        /// </summary>
        /// <returns></returns>
        List<DevolucionViewModel> GetAll();
        /// <summary>
        /// Método que devuelve el detalle del registro
        /// </summary>
        /// <param name="id">id del registro</param>
        /// <returns></returns>
        DevolucionViewModel GetDevolucion(int id);
        /// <summary>
        /// Método que crea un registro
        /// </summary>
        /// <param name="model">entidad a guardar</param>
        /// <returns></returns>
        ResponseHelper Create(DevolucionViewModel model);
        /// <summary>
        /// Método que edita un registro
        /// </summary>
        /// <param name="model">entidad a editar</param>
        /// <returns></returns>
        ResponseHelper Edit(DevolucionViewModel model);
        /// <summary>
        /// Método que elimina el registro seleccionado
        /// </summary>
        /// <param name="id">id del registro</param>
        /// <returns></returns>
        ResponseHelper Delete(int id);
    }
    public class DevolucionService : IDevolucionService
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Devoluciones> _devolucionesRepository;

        public DevolucionService(IDbContextScopeFactory dbContextScopeFactory, IRepository<Devoluciones> devolucionesRepository)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _devolucionesRepository = devolucionesRepository;
        }

        public List<DevolucionViewModel> GetAll()
        {
            var resultado = new List<DevolucionViewModel>();

            try
            {
                using (var context = _dbContextScopeFactory.Create())
                {
                    resultado = context.GetEntity<Devoluciones>()
                        .Select(x => new DevolucionViewModel
                        {
                            Id = x.Id,
                            FechaIngreso = x.FechaIngreso,
                            Producto = x.Producto,
                            Factura = x.Factura
                        }).ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }

            return resultado;
        }
        #region CRUD Devolucion
        public DevolucionViewModel GetDevolucion(int id)
        {
            var resultado = new DevolucionViewModel();

            try
            {
                using (var context = _dbContextScopeFactory.Create())
                {
                    var dbDevolucion = context.GetEntity<Devoluciones>().Where(x => x.Id == id)
                        .FirstOrDefault();

                    resultado.Id = dbDevolucion.Id;
                    resultado.FechaIngreso = dbDevolucion.FechaIngreso;
                    resultado.Cantidad = dbDevolucion.Cantidad;
                    resultado.Producto = dbDevolucion.Producto;
                    resultado.MotivoDevolucion = dbDevolucion.MotivoDevolucion;
                    resultado.Factura = dbDevolucion.Factura;
                    resultado.FechaFactura = dbDevolucion.FechaFactura;
                    resultado.ResponsableRecepcion = dbDevolucion.ResponsableRecepcion;
                }
            }
            catch (Exception e)
            {

                throw;
            }

            return resultado;
        }
        public ResponseHelper Create(DevolucionViewModel model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var context = _dbContextScopeFactory.Create())
                {
                    var devolucion = new Devoluciones
                    {
                        FechaIngreso = model.FechaIngreso,
                        Cantidad = model.Cantidad,
                        Producto = model.Producto,
                        MotivoDevolucion = model.MotivoDevolucion,
                        Factura = model.Factura,
                        FechaFactura = model.FechaFactura,
                        ResponsableRecepcion = model.ResponsableRecepcion
                    };

                    _devolucionesRepository.Insert(devolucion);
                    context.SaveChanges();
                    rh.Response = true;
                }
            }
            catch (Exception)
            {
                rh.Response = false;
                throw;
            }

            return rh;
        }
        public ResponseHelper Edit(DevolucionViewModel model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var context = _dbContextScopeFactory.Create())
                {
                    var devolucion = context.GetEntity<Devoluciones>().Where(x => x.Id == model.Id).FirstOrDefault();

                    devolucion.FechaIngreso = model.FechaIngreso;
                    devolucion.Cantidad = model.Cantidad;
                    devolucion.Producto = model.Producto;
                    devolucion.MotivoDevolucion = model.MotivoDevolucion;
                    devolucion.Factura = model.Factura;
                    devolucion.FechaFactura = model.FechaFactura;
                    devolucion.ResponsableRecepcion = model.ResponsableRecepcion;

                    _devolucionesRepository.Update(devolucion);
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
        public ResponseHelper Delete(int id)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var context = _dbContextScopeFactory.Create())
                {
                    var devolucion = context.GetEntity<Devoluciones>().Where(x => x.Id == id).FirstOrDefault();
                    _devolucionesRepository.Delete(devolucion);
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
