using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ClinicaDeCelulares.Data;
using ClinicaDeCelulares.Library;
using ClinicaDeCelulares.Models;
using ClinicaDeCelulares.Areas.Principal.Controllers;

namespace Sistem_Ventas.Controllers
{
    public class HomeController : Controller
    {
        private Usuarios _usuarios;
        //private SignInManager<IdentityUser> _signInManager;
        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            //_signInManager = signInManager;
            _usuarios = new Usuarios(userManager, signInManager, roleManager);
        }
        public IActionResult Index()
        {
            //if (_signInManager.IsSignedIn(User))
            //{
            //    return RedirectToAction(nameof(PrincipalController.Index), "Principal");
            //}
            //else
            //{
                return View();
            //}

        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Login model)
        {
            if (ModelState.IsValid)
            {
                List<object[]> listObject = await _usuarios.userLogin(model.Input.Email, model.Input.Password);
                object[] objects = listObject[0];
                var _identityError = (IdentityError)objects[0];
                model.ErrorMessage = _identityError.Description;
                if (model.ErrorMessage.Equals("True"))
                {
                    var data = JsonConvert.SerializeObject(objects[1]);
                    //HttpContext.Session.SetString("User",data);
                    return RedirectToAction(nameof(PrincipalController.Index), "Principal");
                }
                else
                {
                    return View(model);
                }
            }

            return View(model);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View()/*(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier })*/;
        }
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            String[] rolesName = { "Admin", "Vende", "Tecni" };
            foreach (var item in rolesName)
            {
                var roleExist = await roleManager.RoleExistsAsync(item);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(item));
                }
            }
            var user = await userManager.FindByIdAsync("0079c93b-46e7-4fd5-a3b0-d47ea2562d8a");
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}
