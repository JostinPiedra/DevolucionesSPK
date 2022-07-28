using Common.CustomFilters;
using Model.Helper;
using System;

namespace Model.Domain
{
    public class Devoluciones: AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string Cantidad { get; set; }
        public string Producto { get; set; }
        public string MotivoDevolucion { get; set; }
        public string Factura { get; set; }
        public DateTime? FechaFactura { get; set; }
        public string ResponsableRecepcion { get; set; }
        public bool Deleted { get; set; }
    }
}
