using MH.PLCM.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MH.PLCM.Controllers
{
    [Area("Admin")]
    public class RolePermissionsController : Controller
    {

        private readonly ApplicationDbContext _db;

        public RolePermissionsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var role = await _db.ApplicationRoles.Include(ar => ar.RolePermissions).ThenInclude(p => p.Permission).AsNoTracking().FirstOrDefaultAsync();
            return View(role);
        }

        public async Task<IActionResult> TreePermissions()
        {
            object permissions = null;
            return View(permissions);
        }

    }
}

