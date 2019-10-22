using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClinicaDeCelulares.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace ClinicaDeCelulares.Controllers
{
    public class HomeController : Controller
    {
        //public HomeController(IServiceProvider serviceProvider)
        //{
        //    CreateRoles(serviceProvider);
        //}
        public IActionResult Index()
        {
            return View();
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

        //private async Task CreateRoles(IServiceProvider serviceProvider)
        //{
        //    String mensaje;
        //    try
        //    {
        //        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //        var userManager = serviceProvider.GetRequiredService<RoleManager<IdentityUser>>();
        //        string[] rolesName = { "Admin", "User" };
        //        foreach (var item in rolesName)
        //        {
        //            var roleExist = await roleManager.RoleExistsAsync(item);
        //            if (!roleExist)
        //            {
        //                await roleManager.CreateAsync(new IdentityRole(item));
        //            }
        //        }
        //        var user = await userManager.FindByIdAsync("6b400e72 - cefd - 4335 - 9fdd - 31684e4a7791");
        //        await userManager.AddToRoleAsync(user, "Admin");
        //    }
        //    cath(Exception ex){

        //    }
        //}
    }
}
