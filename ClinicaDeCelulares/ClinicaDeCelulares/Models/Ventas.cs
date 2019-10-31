using ClinicaDeCelulares.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaDeCelulares.Models
{
    public partial class Ventas
    {
        public Ventas()
        {
           Factura = new List<Factura>();
        }
        [Key]
        public string IdVenta { get; set; }
        [DataType(DataType.Date)]
        public  DateTime Fecha { get; set; }
        public int IdCliente { get; set; }
        //public int IdVendedor { get; set; }
        public decimal SubTotal { get; set; }

        public virtual List<Factura> Factura { get; set; }
        public virtual Vendedor Vendedor { get; set; }
        public virtual Clientes Clientes { get; set; }
    }



#region ViewModels
public class VentaViewModel
    {
        #region Cabecera
        public int Cliente { get; set; }
        public int CabeceraIdProducto { get; set; }
        public string CabeceraNombreProducto { get; set; }
        public int CabeceraCantidadProducto { get; set; }
        public decimal CabeceraPrecioProducto { get; set; }
        #endregion

        #region Contenido
        public List<FacturaViewModel> Factura { get; set; }
        #endregion

        #region Pie
        public decimal SubTotal()
        {
            return Factura.Sum(x => x.Total());
        }
        public DateTime Fecha { get; set; }
        #endregion

        public VentaViewModel()
        {
            Factura = new List<FacturaViewModel>();
            Refrescar();
        }

        public void Refrescar()
        {
            CabeceraIdProducto = 0;
        CabeceraNombreProducto = null;
            CabeceraCantidadProducto = 1;
            CabeceraPrecioProducto = 0;
        }

        public bool SeAgregoUnProductoValido()
        {
            return !(CabeceraIdProducto == 0 || string.IsNullOrEmpty(CabeceraNombreProducto) || CabeceraCantidadProducto == 0 || CabeceraPrecioProducto == 0);
        }

        public bool ExisteEnDetalle(int IdProducto)
        {
            return Factura.Any(x => x.IdProducto == IdProducto);
        }

        public void RetirarItemDeDetalle()
        {
            if (Factura.Count > 0)
            {
                var detalleARetirar = Factura.Where(x => x.Retirar)
                                                        .SingleOrDefault();

                Factura.Remove(detalleARetirar);
            }
        }

        public void AgregarItemADetalle()
        {
        Factura.Add(new FacturaViewModel
        {
                IdProducto = CabeceraIdProducto,
                NombreProducto = CabeceraNombreProducto,
                PrecioUnitario = CabeceraPrecioProducto,
                Cantidad = CabeceraCantidadProducto,
            });

            Refrescar();
        }

        public Ventas ToModel()
        {
            var Ventas = new Ventas();
        Ventas.IdCliente = this.Cliente;
        Ventas.Fecha = DateTime.Now;
        Ventas.SubTotal = this.SubTotal();

            foreach (var d in Factura)
            {
                Ventas.Factura.Add(new Factura
                {
                    IdProducto = d.IdProducto,
                    Total = d.Total(),
                    PrecioUnitario = d.PrecioUnitario,
                    Cantidad = d.Cantidad
                });
            }

            return Ventas;
        }
    }
    #endregion

}
