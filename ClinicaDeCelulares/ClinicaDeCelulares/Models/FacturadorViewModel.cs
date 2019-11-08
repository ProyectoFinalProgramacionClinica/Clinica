using ClinicaDeCelulares.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaDeCelulares.Models
{
    public class FacturadorViewModel
    {
        public Factura Factura { get; set; }
        public Ventas Ventas { get; set; }

        #region 
        
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }

        #endregion
        
    }
}
