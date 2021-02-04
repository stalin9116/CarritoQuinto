using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarritoQuinto.Web.Logica.objetos
{
    public class clsCarrito
    {
        public int numeroProducto { get; set; }
        public int idProducto { get; set; }
        public string codigoProducto { get; set; }
        public int cantidadProducto { get; set; }
        public decimal precioProducto { get; set; }
        public string nombreProducto { get; set; }
        public decimal valor { get; set; }

        public clsCarrito()
        {

        }

    }
}