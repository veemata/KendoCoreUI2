using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MH.PLCM.Core.Entities;
using MH.PLCM.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MH.PLCM.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public RoleController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(_db.ApplicationRoles.ToDataSourceResult(request));
        }

        public IActionResult Create() => View();

        [AcceptVerbs("Post")]
        public async Task<ActionResult> Create([DataSourceRequest] DataSourceRequest request, ApplicationRole role)
        {
            if (role != null && ModelState.IsValid)
            {
                ApplicationRole storeRole = _db.ApplicationRoles
                    .Where(ar => ar.ApplicationRoleId == role.ApplicationRoleId)
                    .FirstOrDefault();
                if (storeRole == null)
                {
                    try
                    {

                        _db.ApplicationRoles.Add(role);
                        await _db.SaveChangesAsync();
                    }
                    catch
                    {
                        ModelState.AddModelError("Add Role", "Some thing went wrong");
                    }

                }
                else
                {
                    // Error How to Communicate
                    ModelState.AddModelError("Add Role", "Some thing went wrong");
                }
            }

            return Json(new[] { role }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs("Post")]
        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request, ApplicationRole role)
        {
            ApplicationRole storeRole = null;
            if (role != null && ModelState.IsValid)
            {
                storeRole = _db.ApplicationRoles.Where(ar => ar.ApplicationRoleId == role.ApplicationRoleId).FirstOrDefault();
                if (storeRole != null)
                {
                    try
                    {
                        _mapper.Map<ApplicationRole, ApplicationRole>(role, storeRole);
                        _db.ApplicationRoles.Update(storeRole);
                        await _db.SaveChangesAsync();
                    }
                    catch
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
