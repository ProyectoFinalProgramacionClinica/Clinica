using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaDeCelulares.Models
{
    public class Clientes   {

        public Clientes()
        {
            Factura = new List<Factura>();
        }
        [Key]
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Direccion { get; set; }
        public string TelefonoCliente { get; set; }
        public string Fax { get; set; }

        public virtual List<Factura> Factura { get; set; }
    }
}
