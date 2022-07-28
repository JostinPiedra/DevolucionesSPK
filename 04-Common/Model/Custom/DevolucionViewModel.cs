using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Custom
{
    public class DevolucionViewModel
    {
        public int Id { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string Cantidad { get; set; }
        public string Producto { get; set; }
        public string MotivoDevolucion { get; set; }
        public string Factura { get; set; }
        public DateTime? FechaFactura { get; set; }
        public string ResponsableRecepcion { get; set; }
    }
}
