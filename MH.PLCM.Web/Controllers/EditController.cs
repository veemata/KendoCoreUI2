
using MH.PLCM.Northwind.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MH.PLCM.Controllers
{

    public class EditController : Controller
    {
     

        public IActionResult Add()
        {
            Category cat = new Category();

            return View(cat);
        }

        [HttpPost]

        public IActionResult Add(Category cat)
        {
          if(ModelState.IsValid)
          {
                //save Category
          }

            return View(cat);
        }
    }
}