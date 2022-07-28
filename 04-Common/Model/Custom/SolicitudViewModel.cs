using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Custom
{
    public class SolicitudViewModel
    {
        public int Id { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public string Cantidad { get; set; }
        public string Producto { get; set; }
        public string MotivoSolicitud { get; set; }
        public string Factura { get; set; }
        public DateTime? FechaFactura { get; set; }
        public string Observacion { get; set; }
        public List<ProductoDataGrid> ProductoDataGrid { get; set; }
    }

    public class ProductoDataGrid
    {
        public string Producto { get; set; }
        public string Cantidad { get; set; }
        public string Motivo { get; set; }
    }
}
