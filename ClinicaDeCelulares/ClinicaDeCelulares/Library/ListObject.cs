using ClinicaDeCelulares.Data;
using ClinicaDeCelulares.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaDeCelulares.Library
{
    public class ListObject /*: IListObject*/
    {
        public String description, code;
        
        public UsersRoles _usersRole { get; set; }
        public UserData _userData { get; set; }
        //public LUsuarios _usuarios { get; set; }
        //public LClientes _clientes { get; set; }
        //public LProveedores _proveedores { get; set; }
        //public LCompras _compras { get; set; }
        //public LProductos _productos { get; set; }
        //public LVentas _ventas { get; set; }
        //public Uploadimage _image { get; set; }
        public IdentityError _identityError { get; set; }
        public ApplicationDbContext _context;
        //public IHostingEnvironment _environment { get; set; }
        public List<SelectListItem> _userRoles { get; set; }
        public RoleManager<IdentityRole> _roleManager { get; set; }
        public UserManager<IdentityUser> _userManager { get; set; }
        public SignInManager<IdentityUser> _signInManager { get; set; }
        //public LCajas _cajas { get; set; }
        public List<object[]> dataList = new List<object[]>();
    }
}
