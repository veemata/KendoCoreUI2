using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MH.PLCM.Core.Entities;
using MH.PLCM.Data;
using MH.PLCM.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MH.PLCM.Controllers
{
    [Area("Admin")]
    public class IdentityUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<IdentityUserController> _logger;
        private readonly ApplicationDbContext _db;


        public IdentityUserController(SignInManager<ApplicationUser> signInManager,
            ILogger<IdentityUserController> logger,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            RegisterInputDto dto = new RegisterInputDto();
            return View(dto);
        }

        public JsonResult Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(_userManager.Users.ToDataSourceResult(request));
        }

        [AcceptVerbs("Post")]
        public void Register(RegisterInputDto modelUser)
        {

            if (modelUser != null && ModelState.IsValid)
            {

                ApplicationUser user = new ApplicationUser { UserName = modelUser.Email, Email = modelUser.Email };
                IdentityResult result = _userManager.CreateAsync(user, modelUser.Password).Result;

                if (result != IdentityResult.Success)
                {
                    ModelState.AddModelError("User", "Failed to Create User");
                }
            }

            Response.Redirect(Url.Action("Index"));
        }

        [AcceptVerbs("Post")]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, ApplicationUser user)
        {
            if (user != null && ModelState.IsValid)
            {
                _userManager.UpdateAsync(user);
            }

            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
        public ActionResult Lockout([DataSourceRequest] DataSourceRequest request, ApplicationUser user)
        {
            if (user != null)
            {
                _userManager.SetLockoutEndDateAsync(user, DateTime.Now);
            }

            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
        public async Task<JsonResult> UserRoles(string userId)
        {
            List<UserRoleDto> userInRoles = new List<UserRoleDto>();
            var user = await _userManager.FindByIdAsync(userId);

            var roles = await _userManager.GetRolesAsync(user);
            foreach (string s in roles)
            {
                userInRoles.Add(new UserRoleDto { RoleName = s });
            }
            return Json(userInRoles);
        }

    }



}