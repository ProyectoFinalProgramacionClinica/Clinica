using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaDeCelulares.Models
{
    public class Productos
    {
        public int IdProducto { get; set; }
        public string nombreProducto { get; set; }
        public decimal precioUnidad { get; set; }
        public int unidadesEnExistencia { get; set; }
        public int idProveedor { get; set; }
        public int idCategoria { get; set; }


        public virtual Proveedores Proveedores { get; set; }
        public virtual Categorias Categorias { get; set; }
    }
}
