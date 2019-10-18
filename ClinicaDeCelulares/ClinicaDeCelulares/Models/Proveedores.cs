using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaDeCelulares.Models
{
    public class Proveedores
    {
        [Key]
        public int idProveedor { get; set; }
        public int compania { get; set; }
        public int nombreRepresentante { get; set; }
        public string telefonoProveedor { get; set; }
    }
}
