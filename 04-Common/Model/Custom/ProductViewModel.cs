using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Custom
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string CodigoProducto { get; set; }
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public string CodigoBarra { get; set; }
        public string ImgUrl { get; set; }
    }
}
