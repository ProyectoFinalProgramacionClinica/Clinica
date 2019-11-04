using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaDeCelulares.Models
{
    public class Vendedor
    {
        [Key]
        public int IdVendedor { get; set; }
        public string NombreVendedor { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }

        public Vendedor(int idVendedor, string NombreVendedor, string Cedula, string Telefono)
        {
            this.IdVendedor = idVendedor;
            this.NombreVendedor = NombreVendedor;
            this.Cedula = Cedula;
            this.Telefono = Telefono;
            Factura = new List<Factura>();
        }

        public Vendedor()
        {
            Factura = new List<Factura>();
        }

        public virtual List<Factura> Factura { get; set; }
    }
}
