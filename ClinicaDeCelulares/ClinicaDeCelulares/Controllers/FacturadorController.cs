using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicaDeCelulares.Data;
using ClinicaDeCelulares.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AppFacturador.Controllers
{
    public class FacturadorController : Controller
    {
        private readonly ApplicationDbContext context;

        public FacturadorController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(ListarVentas());
        }

        public JsonResult BuscarProducto(string nombre)
        {
            return Json(ListarNombresProductos(nombre));
        }
        public JsonResult BuscarClientes(string nombre)
        {
            return Json(ListarNombresClientes(nombre));
        }

        public ActionResult Registrar()
        {
            ViewData["IdProducto"] = new SelectList(context.Productos, "IdNombre", "Nombre");
            return View(new VentaViewModel());
        }

        [HttpPost]
        public ActionResult Registrar(VentaViewModel model, string action)
        {
            if (action == "generar")
            {
                if (!string.IsNullOrEmpty(model.Cliente.ToString()))
                {
                    if (RegistrarVenta(model.ToModel()))
                    {
                        return Redirect("~/");
                    }
                }
                else
                {
                    ModelState.AddModelError("cliente", "Debe agregar un cliente para el comprobante");
                }
            }
            else if (action == "agregar_producto")
            {
                // Si no ha pasado nuestra validación, mostramos el mensaje personalizado de error
                if (!model.SeAgregoUnProductoValido())
                {
                    ModelState.AddModelError("producto_agregar", "Solo puede agregar un producto válido al detalle");
                }
                else if (model.ExisteEnDetalle(model.CabeceraIdProducto))
                {
                    ModelState.AddModelError("producto_agregar", "El producto elegido ya existe en el detalle");
                }
                else
                {
                    model.AgregarItemADetalle();
                }
            }
            else if (action == "retirar_producto")
            {
                model.RetirarItemDeDetalle();
            }
            else
            {
                throw new Exception("Acción no definida ..");
            }

            return View(model);
        }

        public string ProductosJSON(int id)
        {
            var query = from p in context.Productos where p.IdProducto == id
                        select new
                        {
                            Id = p.IdProducto,
                            Nombre = p.nombreProducto,
                            Precio = p.precioUnidad
                        };

            return Newtonsoft.Json.JsonConvert.SerializeObject(query);
        }


        #region NoAction
        public bool RegistrarVenta(Ventas ventas)
        {
            try
            {
                context.Entry(ventas).State = EntityState.Added;
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public List<Ventas> ListarVentas()
        {
            return context.Ventas.OrderByDescending(x => x.Fecha)
                                      .ToList();
        }
        public List<Productos> ListarNombresProductos(string nombre)
        {
            var productos = context.Productos.OrderBy(x => x.nombreProducto)
                                    .Where(x => x.nombreProducto.Contains(nombre))
                                    .Take(10)
                                    .ToList();
            return productos;
        }
        public List<Clientes> ListarNombresClientes(string nombre)
        {
            var clientes = context.Clientes.OrderBy(x => x.NombreCliente)
                                    .Where(x => x.NombreCliente.Contains(nombre))
                                    .Take(10)
                                    .ToList();
            return clientes;
        }
        #endregion

    }
}