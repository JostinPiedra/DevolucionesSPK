using Common.CustomFilters;
using Model.Helper;
using System;

namespace Model.Domain
{
    public class Solicitudes: AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public string Cantidad { get; set; }
        public string Producto { get; set; }
        public string MotivoSolicitud { get; set; }
        public string Factura { get; set; }
        public DateTime? FechaFactura { get; set; }
        public string Observacion { get; set; }
        public bool Deleted { get; set; }
    }
}
