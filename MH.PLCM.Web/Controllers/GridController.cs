
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MH.PLCM.Models;
using MH.PLCM.Northwind.Entities;
using MH.PLCM.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Linq;
using System.Security.Claims;

namespace MH.PLCM.Controllers
{
   
    public class GridController : Controller
    {

        private readonly ILogger<GridController> _logger;
        private readonly NorthwindService _srv;
        private readonly UserManager<ApplicationUser> _userManager;

        public GridController(ILogger<GridController> logger, 
            NorthwindService srv, UserManager<ApplicationUser> usrManager)
        {
            _logger = logger;
            _srv = srv;
            _userManager = usrManager;


        }


        public IActionResult Index()
        {
            return View();
        }


        #region User Applicaiton Settings



        public string GetProductGridSettings()
        {
            string key = "Plcm.Grid.UserBuiltQuery.ProductGrid";

            UserSetting setting = _srv.GetUserSetting(this.User.FindFirstValue(ClaimTypes.NameIdentifier), key, 1);
            if (setting != null)
            {
                return setting.SettingValue;
            }
            else
            {
                return "";
            }
        }

        [AcceptVerbs("POST")]
        public void SaveProductGridSettings(string optionsData)
        {
            string key = "Plcm.Grid.UserBuiltQuery.ProductGrid";
            UserSetting setting = new UserSetting();
            setting.SettingKey = key;
            setting.SettingValue = optionsData;
            setting.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _srv.AddUserSetting(setting);

        }

        public string GetProductGridFilterSettings()
        {
            string key = "Plcm.Grid.UserBuiltQuery.ProductGrid.Filter";

           UserSetting setting = _srv.GetUserSetting(this.User.FindFirstValue(ClaimTypes.NameIdentifier), key, 1);
            if (setting != null)
            {
                return setting.SettingValue;
            }
            else
            {
                return "";
            }
        }

        [AcceptVerbs("POST")]
        public void SaveGridFilterSettings(string optionsData)
        {
            string key = "Plcm.Grid.UserBuiltQuery.ProductGrid.Filter";
            UserSetting setting = new UserSetting();
            setting.SettingKey = key;
            setting.SettingValue = optionsData;
            setting.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _srv.AddUserSetting(setting);
        }
       
        #endregion      

  
        #region GridView
        public IActionResult GridList()
        {


            return View();
        }

        #endregion


        #region Hierarchy Binding
        public IActionResult ParentChild()
        {
            return View();
        }

        public ActionResult HierarchyBinding_Employees([DataSourceRequest] DataSourceRequest request)
        {
            return FormatDataResult(_srv.GetEmployees(), request);
        }

        public ActionResult HierarchyBinding_Orders(int employeeID, [DataSourceRequest] DataSourceRequest request)
        {
            return FormatDataResult(_srv.GetOrdersByEmployee(employeeID), request);
        }

        #endregion

        #region Popup Edit Grid


        public IActionResult GridEdit()
        {
            return View();
        }

        public ActionResult EditingPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
          
            return FormatDataResult(_srv.GetProducts(),request);
        }

    
        public ActionResult EditingPopup_Create([DataSourceRequest] DataSourceRequest request, Product product)
        {
            if (product != null && ModelState.IsValid)
            {
                _srv.CreateProduct(product);
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }

     
        public ActionResult EditingPopup_Update([DataSourceRequest] DataSourceRequest request, Product product)
        {
            if (product != null && ModelState.IsValid)
            {
                _srv.UpdateProduct(product);
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }

       
        public ActionResult EditingPopup_Destroy([DataSourceRequest] DataSourceRequest request, Product product)
        {
            if (product != null)
            {
                try
                {
                    _srv.DeleteProduct(product.ProductId);
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "There is something wrong with Foo.");
                }
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }
        #endregion

        #region Create/Edit

        public IActionResult Create()
        {
            var p = _srv.GetProduct(11);
            return View(p);
        }

        public JsonResult GetSuppliers_Dropdown()
        {

            return FormatDataResult(_srv.GetSupplierDropDown().ToList());
        }

        public JsonResult GetCategories_Dropdown()
        {
            return FormatDataResult(_srv.GetCategoryDropdowns().ToList());
        }

        #endregion

        #region User Built Query
        public IActionResult UserBuiltQuery()
        {
            return View();
        }

        #endregion

        #region Master Details
        public IActionResult MasterDetail()
        {
            return View();
        }
  
        
        public IActionResult Products_Read([DataSourceRequest] DataSourceRequest request, int? CategoryId)
        {
            if (CategoryId.HasValue)
            {
                var products = _srv.GetProducts().Where(p => p.CategoryId == CategoryId);
                return (FormatDataResult(products, request));
            }
            else
            {
                return (FormatDataResult(_srv.GetProducts(), request));
            }
        }

        public IActionResult Categories_Read([DataSourceRequest] DataSourceRequest request)
        {
            return (FormatDataResult(_srv.GetCategories(), request));
        }
        #endregion

        #region Other



        public IActionResult Privacy()
        {
            return View();
        }



        #endregion

        #region Helper
        private JsonResult FormatDataResult(IEnumerable input, DataSourceRequest request)
        {
            return Json(input.ToDataSourceResult(request));
        }

        private JsonResult FormatDataResult(object entity)
        {
            return Json(entity);
        }

        #endregion



    }
}

