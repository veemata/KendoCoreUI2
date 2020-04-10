using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MH.PLCM.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> roleMgr)
        {
            roleManager = roleMgr;
        }


        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Roles_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(roleManager.Roles.ToDataSourceResult(request));
        }


        public IActionResult Create() => View();

        [AcceptVerbs("Post")]
        public async Task<ActionResult> Role_Create([DataSourceRequest] DataSourceRequest request, IdentityRole role)
        {
            if (role != null && ModelState.IsValid)
            {
                IdentityRole storeRole = await roleManager.FindByNameAsync(role.Name);
                if (storeRole == null)
                {
                    IdentityResult result = await roleManager.CreateAsync(new IdentityRole(role.Name));
                    if (result.Succeeded)
                    {

                    }
                    else
                    {
                        // Error how to communicate
                    }
                }
                else
                {
                    // Error How to Communicate
                }
            }

            return Json(new[] { role }.ToDataSourceResult(request, ModelState));
        }



        [AcceptVerbs("Post")]
        public async Task<ActionResult> Role_Update([DataSourceRequest] DataSourceRequest request, IdentityRole role)
        {
            IdentityRole storeRole = null;
            if (role != null && ModelState.IsValid)
            {
                storeRole = await roleManager.FindByIdAsync(role.Id);
                if (storeRole != null)
                {
                    storeRole.Name = role.Name;
                    IdentityResult result = await roleManager.UpdateAsync(storeRole);
                    storeRole = await roleManager.FindByIdAsync(role.Id);  // Get Updated Values like Normalized Name
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("Role", "Role doesn't exist");     
                    }
                }
                else
                {
                    //If error just send back what your got
                    storeRole = role;
                    ModelState.AddModelError("Role", "Role doesn't exist");
                }
                
            }

            return Json(new[] { storeRole }.ToDataSourceResult(request, ModelState));
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}
