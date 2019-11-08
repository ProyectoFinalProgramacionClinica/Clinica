using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicaDeCelulares.Data;
using ClinicaDeCelulares.Models;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace ClinicaDeCelulares.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Productos
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Productos.Include(p => p.Categorias).Include(p => p.Proveedores);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos
                .Include(p => p.Categorias)
                .Include(p => p.Proveedores)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["idCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "IdCategoria");
            ViewData["idProveedor"] = new SelectList(_context.Set<Proveedores>(), "idProveedor", "idProveedor");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProducto,nombreProducto,precioUnidad,unidadesEnExistencia,idProveedor,idCategoria")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "IdCategoria", productos.idCategoria);
            ViewData["idProveedor"] = new SelectList(_context.Set<Proveedores>(), "idProveedor", "idProveedor", productos.idProveedor);
            return View(productos);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }
            ViewData["idCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "IdCategoria", productos.idCategoria);
            ViewData["idProveedor"] = new SelectList(_context.Set<Proveedores>(), "idProveedor", "idProveedor", productos.idProveedor);
            return View(productos);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProducto,nombreProducto,precioUnidad,unidadesEnExistencia,idProveedor,idCategoria")] Productos productos)
        {
            if (id != productos.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductosExists(productos.IdProducto))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["idCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "IdCategoria", productos.idCategoria);
            ViewData["idProveedor"] = new SelectList(_context.Set<Proveedores>(), "idProveedor", "idProveedor", productos.idProveedor);
            return View(productos);
        }

        public ActionResult EditField(int id, string field, string value)
        {
            bool status = false; string mensaje = "Valor no establecido";
            Productos productos = (from a in _context.Productos
                                     where a.IdProducto == id
                                     select a).FirstOrDefault();
            switch (field)
            {
                case "Nombre":
                    productos.nombreProducto = value.Trim();
                    break;
                case "Precio":
                    productos.precioUnidad = Int32.Parse(value);
                    break;
                case "Existencia":
                    productos.unidadesEnExistencia = Int32.Parse(value);
                    break;
                case "Compañia":
                    productos.idProveedor = Int32.Parse(value);
                    break;
                case "Categoria":
                    productos.idProveedor = Int32.Parse(value);
                    break;

            }
            _context.SaveChanges();
            status = true;
            mensaje = "Valor establecido";
            return Json(new { value = value, status = status, mensaje = mensaje });
        }

        public string Ids_ProveedoresJSON()
        {
            StringBuilder sb = new StringBuilder();
            var datos = _context.Proveedores.ToList();
            foreach (var item in datos)
                sb.Append(string.Format("'{0}':'{1}',", item.idProveedor, item.compania));
            return "{" + sb.ToString() + "}";
        }
        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos
                .Include(p => p.Categorias)
                .Include(p => p.Proveedores)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (productos == null)
            {
                return NotFound();
            }

            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productos = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(productos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductosExists(int id)
        {
            return _context.Productos.Any(e => e.IdProducto == id);
        }
    }
}
