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
    public interface ISolicitudService
    {
        /// <summary>
        /// Método que devuelve todos los registros
        /// </summary>
        /// <returns></returns>
        List<SolicitudViewModel> GetAll();
        /// <summary>
        /// Método que devuelve el detalle del registro
        /// </summary>
        /// <param name="id">id del registro</param>
        /// <returns></returns>
        SolicitudViewModel GetSolicitud(int id);
        /// <summary>
        /// Método que crea un registro
        /// </summary>
        /// <param name="model">entidad a guardar</param>
        /// <returns></returns>
        ResponseHelper Create(SolicitudViewModel model);
        /// <summary>
        /// Método que edita un registro
        /// </summary>
        /// <param name="model">entidad a editar</param>
        /// <returns></returns>
        ResponseHelper Edit(SolicitudViewModel model);
        /// <summary>
        /// Método que elimina el registro seleccionado
        /// </summary>
        /// <param name="id">id del registro</param>
        /// <returns></returns>
        ResponseHelper Delete(int id);
    }
    public class SolicitudService : ISolicitudService
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Solicitudes> _devolucionesRepository;

        public SolicitudService(IDbContextScopeFactory dbContextScopeFactory, IRepository<Solicitudes> devolucionesRepository)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _devolucionesRepository = devolucionesRepository;
        }

        public List<SolicitudViewModel> GetAll()
        {
            var resultado = new List<SolicitudViewModel>();

            try
            {
                using (var context = _dbContextScopeFactory.Create())
                {
                    resultado = context.GetEntity<Solicitudes>()
                        .Select(x => new SolicitudViewModel
                        {
                            Id = x.Id,
                            FechaSolicitud = x.FechaSolicitud,
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

        #region CRUD Solicitud
        public SolicitudViewModel GetSolicitud(int id)
        {
            var resultado = new SolicitudViewModel();

            try
            {
                using (var context = _dbContextScopeFactory.Create())
                {
                    var dbDevolucion = context.GetEntity<Solicitudes>().Where(x => x.Id == id)
                        .FirstOrDefault();

                    resultado.Id = dbDevolucion.Id;
                    resultado.FechaSolicitud = dbDevolucion.FechaSolicitud;
                    resultado.Cantidad = dbDevolucion.Cantidad;
                    resultado.Producto = dbDevolucion.Producto;
                    resultado.MotivoSolicitud = dbDevolucion.MotivoSolicitud;
                    resultado.Factura = dbDevolucion.Factura;
                    resultado.FechaFactura = dbDevolucion.FechaFactura;
                    resultado.Observacion = dbDevolucion.Observacion;
                }
            }
            catch (Exception e)
            {

                throw;
            }

            return resultado;
        }
        public ResponseHelper Create(SolicitudViewModel model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var context = _dbContextScopeFactory.Create())
                {
                    var devolucion = new Solicitudes
                    {
                        FechaSolicitud = model.FechaSolicitud,
                        Cantidad = model.Cantidad,
                        Producto = model.Producto,
                        MotivoSolicitud = model.MotivoSolicitud,
                        Factura = model.Factura,
                        FechaFactura = model.FechaFactura,
                        Observacion = model.Observacion
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
        public ResponseHelper Edit(SolicitudViewModel model)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var context = _dbContextScopeFactory.Create())
                {
                    var devolucion = context.GetEntity<Solicitudes>().Where(x => x.Id == model.Id).FirstOrDefault();

                    devolucion.FechaSolicitud = model.FechaSolicitud;
                    devolucion.Cantidad = model.Cantidad;
                    devolucion.Producto = model.Producto;
                    devolucion.MotivoSolicitud = model.MotivoSolicitud;
                    devolucion.Factura = model.Factura;
                    devolucion.FechaFactura = model.FechaFactura;
                    devolucion.Observacion = model.Observacion;

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
                    var devolucion = context.GetEntity<Solicitudes>().Where(x => x.Id == id).FirstOrDefault();
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
