using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MH.PLCM.Data;
using MH.PLCM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace MH.PLCM.Controllers
{
    public class PermissionController: Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public PermissionController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult PermissionsRead([DataSourceRequest]DataSourceRequest request)
        {
            return Json(_db.Permissions.AsNoTracking().ToDataSourceResult(request));
        }

        [HttpGet]
        public IActionResult PermissionCreate()
        {
            return View(new Permission());
        }

        [HttpPost]
        public ActionResult PermissionCreate([DataSourceRequest] DataSourceRequest request, Permission per)
        {
            Permission storePerm = null;
            if (per != null && ModelState.IsValid)
            {
                _db.Permissions.Add(per);
                _db.SaveChanges();
                storePerm = _db.Permissions.Where(p => p.PermissionName == per.PermissionName).FirstOrDefault();
            }
            else
            {

            }
            return Json(new[] { storePerm }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult PermissionUpdate([DataSourceRequest] DataSourceRequest request, Permission per)
        {
            Permission storePerm = _db.Permissions.Where(p => p.PermissionId == per.PermissionId).FirstOrDefault();
            if (storePerm != null && ModelState.IsValid)
            {
                // Map from object returned to object attached to context
                _mapper.Map<Permission, Permission>(per, storePerm);
                _db.Permissions.Update(storePerm);
                _db.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("Add Permission", "Permission does not exist to update");
            }
            return Json(new[] { storePerm }.ToDataSourceResult(request, ModelState));
        }

    }
}
