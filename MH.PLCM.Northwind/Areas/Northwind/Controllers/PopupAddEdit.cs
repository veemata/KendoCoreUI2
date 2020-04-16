using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MH.PLCM.Data;
using MH.PLCM.Northwind.Entities;
using Microsoft.EntityFrameworkCore;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MH.PLCM.Northwind.Web.Areas.Northwind.Controllers
{
    [Area("Northwind")]
    public class PopupAddEdit : Controller
    {
        private readonly NorthwindContext _db;
        public PopupAddEdit(NorthwindContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var cat = _db.Categories;
            return View(cat);
        }

        [HttpGet]
        public IActionResult Category(int? Id)
        {
            Category cat = null;
            if (Id.HasValue && Id.Value != 0)
            {
                cat = _db.Categories.Where(cat => cat.CategoryId == Id).SingleOrDefault();
            }
            else
            {
                cat = new Category();
            }

            return PartialView("_AddEditCategory", cat);
        }

        [HttpPost]
        public IActionResult Category(Category model)
        {
            if (model != null && ModelState.IsValid)
            {
                if (model.CategoryId == 0)
                {
                    _db.Categories.Add(model);
                    _db.SaveChanges();
                }
                else
                {
                    var cat = _db.Categories.Where(cat => cat.CategoryId == model.CategoryId).SingleOrDefault();
                    //map it using automapper and save it
                }
            }
            else
            {
                ModelState.AddModelError("Manage Category", "Add/Edit failed");
            }
            return PartialView("_AddEditCategory", model);
        }

        [HttpPost]
        public IActionResult Delete(int? Id)
        {
            if(Id.HasValue && Id.Value !=0)
            {
                var category = new Category { CategoryId = Id.Value };
                _db.Entry(category).State = EntityState.Deleted;
                _db.SaveChanges();
            }
            {
                ModelState.AddModelError("Manage Category", "Category Delete Failed");
            }
            return RedirectToAction("Index");
        }
    }
}
