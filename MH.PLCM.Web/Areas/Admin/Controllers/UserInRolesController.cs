﻿using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MH.PLCM.Data;
using MH.PLCM.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MH.PLCM.Controllers
{
    [Area("Admin")]
    public class UserInRolesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserInRolesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            PopulateRolesDrowpdown();
            return View();
        }


        public JsonResult Read([DataSourceRequest] DataSourceRequest request)
        {
            UserInRolesDto uir = new UserInRolesDto();
            uir.User = _db.Users.FirstOrDefault();
            uir.Roles = GetUserRoles(uir.User.Id);
            return Json(uir.Roles.ToDataSourceResult(request));
        }

        private List<ApplicationUserRoleViewModel> GetUserRoles(string UserId)
        {
            var roles = _db.UserApplicationRoles
                 .Where(ar => ar.UserId == UserId)
                 .Select(r => new ApplicationUserRoleViewModel
                 {
                     ApplicationRoleId = r.ApplicationRoleId,
                     ApplicationRoleViewModel = new ApplicationRoleViewModel
                     {
                         ApplicationRoleId = r.ApplicationRoleId,
                         ApplicationRoleName = r.ApplicationRole.ApplicationRoleName
                     }
                 }).ToList();
            return (roles);
        }

        public JsonResult GetRolesList()
        {
            var roles = _db.ApplicationRoles
                        .Select(ro => new ApplicationRoleViewModel
                        {
                            ApplicationRoleId = ro.ApplicationRoleId,
                            ApplicationRoleName = ro.ApplicationRoleName
                        }
                        ).ToList();

            return Json(roles);
        }

        private void PopulateRolesDrowpdown()
        {
            var roles = _db.ApplicationRoles
                         .Select(ro => new ApplicationRoleViewModel
                         {
                             ApplicationRoleId = ro.ApplicationRoleId,
                             ApplicationRoleName = ro.ApplicationRoleName
                         }
                         ).ToList();
            ViewData["applicationRoles"] = roles;
            ViewData["applicationRoles"] = roles.First();
        }

        [HttpPost]
        public JsonResult Create([DataSourceRequest] DataSourceRequest request, List<ApplicationUserRoleViewModel> roles)
        {
            return Json(new { });
        }



    }
}