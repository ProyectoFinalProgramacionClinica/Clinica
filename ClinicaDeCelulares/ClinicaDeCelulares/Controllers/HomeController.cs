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
        IServiceProvider _serviceProvider;
        public HomeController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task<IActionResult> Index()
        {
            await CreateRoles(_serviceProvider);
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
