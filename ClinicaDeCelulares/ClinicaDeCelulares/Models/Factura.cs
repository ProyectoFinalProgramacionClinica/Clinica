using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaDeCelulares.Models
{
    public class Factura
    {
        [Key]
        public int IdFactura { get; set; }
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public int IdVendedor { get; set; }
        public int IdProducto { get; set; }
        [DataType(DataType.Date)]
        public string Fecha { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Total { get; set; }
       
        public int Cantidad  { get; set; }
       
        public virtual Ventas Ventas { get; set; }
        public virtual Productos Productos { get; set; }
        public virtual Vendedor Vendedor  { get; set; }
    }
    #region ViewModels
    public partial class FacturaViewModel
    {
        public int IdProducto { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string NombreProducto { get; set; }
        [DataType(DataType.Date)]
        public string IFecha { get; set; }
       
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public bool Retirar { get; set; }

        public decimal Total()
        {
            return Cantidad * PrecioUnitario;
        }
    }
    #endregion
}
