using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MH.PLCM.Controllers
{
    public class UserInRolesController : Controller
    {
        public IActionResult Index(string UserId)
        {
            return View();
        }
    }
}