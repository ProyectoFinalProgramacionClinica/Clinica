using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClinicaDeCelulares.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using ClinicaDeCelulares.Library;
using Newtonsoft.Json;
using ClinicaDeCelulares.Areas.Principal.Controllers;

namespace ClinicaDeCelulares.Controllers
{
    public class HomeController : Controller
    {
        private LUsuarios _usuarios;
        IServiceProvider _serviceProvider;
        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
           
             _usuarios = new LUsuarios(userManager, signInManager, roleManager, context);
        }
        // public async Task<IActionResult> Index()
        public IActionResult Index()
        {
            //await CreateRoles(_serviceProvider);
            return View();
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
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
