using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ClinicaDeCelulares.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicaDeCelulares.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ClinicaDeCelulares.Models.Clientes> Clientes { get; set; }
        public DbSet<ClinicaDeCelulares.Models.Categorias> Categorias { get; set; }
        public DbSet<ClinicaDeCelulares.Models.Productos> Productos { get; set; }
        public DbSet<ClinicaDeCelulares.Models.Proveedores> Proveedores { get; set; }

    }
}
