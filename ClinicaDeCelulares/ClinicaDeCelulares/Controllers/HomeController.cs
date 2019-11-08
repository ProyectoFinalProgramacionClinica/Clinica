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

namespace ClinicaDeCelulares.Controllers
{
    public class HomeController : Controller
    {
    
    IServiceProvider _serviceProvider;
        public HomeController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            //await CreateRoles(_serviceProvider);
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
        //    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //    var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        //    String[] rolesName = { "Admin", "Vende"};
        //    foreach (var item in rolesName)
        //    {
        //        var roleExist = await roleManager.RoleExistsAsync(item);
        //        if (!roleExist)
        //        {
        //            await roleManager.CreateAsync(new IdentityRole(item));
        //        }
        //    }
        //    var user = await userManager.FindByIdAsync("eba98458-972a-49d6-8527-98b9ae160c8e");
        //    await userManager.AddToRoleAsync(user, "Vende");
        //}
    }
}
