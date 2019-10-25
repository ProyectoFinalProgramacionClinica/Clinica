using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaDeCelulares.Library
{
    public class UsersRoles : ListObject
    {
        public UsersRoles()
        {
            _userRoles = new List<SelectListItem>();
        }
        public async Task<List<SelectListItem>> getRole(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, string ID)
        {
            var users = await userManager.FindByIdAsync(ID);//Guarda en user la informacion de usuarios de cada ID que quiera iniciar sesion
            var roles = await userManager.GetRolesAsync(users);//Obtiene el rol de usuario en el objeto roles
            if (roles.Count.Equals(0))
            {
                _userRoles.Add(new SelectListItem {// instancia la clase 
                    Value = "0",
                    Text = "No role"
                });
            }
            else
            {
                var roleUser = roleManager.Roles.Where(m => m.Name.Equals(roles[0]));
                foreach (var Data in roleUser)
                {
                    _userRoles.Add(new SelectListItem
                    {
                        Value = Data.Id,
                        Text = Data.Name
                    });
                }
            }
            return _userRoles;
        }
        public List<SelectListItem> getRoles(RoleManager<IdentityRole> roleManager)
        {
            var roles = roleManager.Roles.ToList();
            roles.ForEach(item => {

                _userRoles.Add(new SelectListItem {

                    Value = item.Id,
                    Text = item.Name
                });
            });
            return _userRoles;
        }
    }
}
