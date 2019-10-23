using ClinicaDeCelulares.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace ClinicaDeCelulares.Library
{
    public class ListObject
    {
        public String description, code;

        public UsersRoles _usersRole;
        //public UserData _userData;
        public LUsuarios _usuarios;
        public Uploadimage _image;
        public IdentityError _identityError;
        public ApplicationDbContext _context;
        public IHostingEnvironment _environment;

        public List<SelectListItem> _userRoles;

        public RoleManager<IdentityRole> _roleManager;
        public UserManager<IdentityUser> _userManager;
        public SignInManager<IdentityUser> _signInManager;

        public List<object[]> dataList = new List<object[]>();
    }
}
