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
            var permissions = await _db.Permissions.AsNoTracking().ToListAsync();
            /*
            var employees = from e in dataContext.Employees
                            where (id.HasValue ? e.ReportsTo == id : e.ReportsTo == null)
                            select new
                            {
                                id = e.EmployeeID,
                                Name = e.FirstName + " " + e.LastName,
                                hasChildren = (from q in dataContext.Employees
                                               where (q.ReportsTo == e.EmployeeID)
                                               select q
                                               ).Count() > 0
                            };
            */
            return View(permissions);
        }

    }
}

