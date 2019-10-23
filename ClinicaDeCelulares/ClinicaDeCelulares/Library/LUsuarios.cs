﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

using ClinicaDeCelulares.Data;
using ClinicaDeCelulares.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaDeCelulares.Library
{
    public class LUsuarios : ListObject
    {
        public LUsuarios()
        {

        }
        public LUsuarios(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _usersRole = new UsersRoles();
        }
        public LUsuarios(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
            _usersRole = new UsersRoles();
        }
        internal async Task<List<object[]>> userLogin(string email, string password)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var appUser1 = _userManager.Users.Where(u => u.Email.Equals(email)).ToList();
                   _userRoles = await _usersRole.getRole(_userManager, _roleManager, appUser1[0].Id);

                    _userData = new UserData
                    {
                    

                    };
                    code = "0";
                    description = result.Succeeded.ToString();
                }
                else
                {
                    code = "1";
                    description = "Correo o contraseña inválidos";
                }
            }
            catch (Exception ex)
            {

                code = "2";
                description = ex.Message;
            }
            _identityError = new IdentityError
            {
                Code = code,
                Description = description
            };
            object[] data = { _identityError, _userData };
            dataList.Add(data);

            return dataList;
        }
        //    public async Task<List<InputModelRegistrar>> getTUsuariosAsync(String valor)
        //    {
        //        List<TUsuarios> listUser;
        //        if (valor == null)
        //        {
        //            listUser = _context.TUsuarios.ToList();
        //        }
        //        else
        //        {
        //            listUser = _context.TUsuarios.Where(u => u.NID.StartsWith(valor) || u.Nombre.StartsWith(valor) || u.Apellido.StartsWith(valor) || u.Imagen.StartsWith(valor)).ToList();
        //        }
        //        List<InputModelRegistrar> userList = new List<InputModelRegistrar>();

        //        foreach (var item in listUser)
        //        {
        //            _userRoles = await _usersRole.getRole(_userManager, _roleManager, item.IdUser);
        //            userList.Add(new InputModelRegistrar
        //            {
        //                Id = item.ID,
        //                ID = item.IdUser,
        //                NID = item.NID,
        //                Nombre = item.Nombre,
        //                Apellido = item.Apellido,
        //                Role = _userRoles[0].Text,
        //                Email = item.Imagen
        //            });
        //            _userRoles.Clear();
        //        }
        //        return userList;
        //    }
        //   /* public String userData(HttpContext HttpContext)
        //    {
        //        String role = null;
        //        var user = HttpContext.Session.GetString("User");
        //        if (user != null)
        //        {
        //            UserData dataItem = JsonConvert.DeserializeObject<UserData>(user.ToString());
        //            role = dataItem.Role;
        //        }
        //        else
        //        {
        //            role = "No data";
        //        }
        //        return role;
        //    }*/
    }
}
