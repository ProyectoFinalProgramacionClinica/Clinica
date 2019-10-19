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
        public string compania { get; set; }
        public string nombreRepresentante { get; set; }
        public string telefonoProveedor { get; set; }
    }
}
