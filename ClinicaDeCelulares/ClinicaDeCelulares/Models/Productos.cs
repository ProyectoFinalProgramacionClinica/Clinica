using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaDeCelulares.Models
{
    public class Productos
    {
        [Key]
        public int IdProducto { get; set; }
        public string nombreProducto { get; set; }
        public decimal precioUnidad { get; set; }
        public int unidadesEnExistencia { get; set; }
        public int idProveedor { get; set; }
        public int idCategoria { get; set; }

        [ForeignKey("idProveedor")]
        public virtual Proveedores Proveedores { get; set; }
        [ForeignKey("idCategoria")]
        public virtual Categorias Categorias { get; set; }
    }
}
