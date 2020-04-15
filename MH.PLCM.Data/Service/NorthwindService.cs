using MH.PLCM.Data;
using MH.PLCM.Northwind.Entities;
using MH.PLCM.Northwind.ViewModels;
using MH.PLCM.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;


namespace MH.PLCM.Service
{
    public class NorthwindService
    {
        private NorthwindContext db;
        public NorthwindService(NorthwindContext ctx)
        {
            db = ctx;
        }


        #region Heirarchy binding
        public IEnumerable<EmployeeViewModel> GetEmployees()
        {

            return (db.Employees.Select(employee => new EmployeeViewModel
            {
                EmployeeID = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Country = employee.Country,
                City = employee.City,
                Notes = employee.Notes,
                Title = employee.Title,
                Address = employee.Address,
                HomePhone = employee.HomePhone
            }));
        }

        public IQueryable<Order> GetOrdersByEmployee(int employeeId)
        {
            return (db.Orders.Where(order => order.EmployeeId == employeeId));

        }



        #endregion

        #region Products



        public IQueryable<Product> GetProducts()
        {
            return db.Products;
        }
        public Product GetProduct(int id)
        {
            return (db.Products.Where(p => p.ProductId == id).FirstOrDefault());
        }

        public void CreateProduct(Product p)
        {

        }

        public void DeleteProduct(int productId)
        {

            var product = db.Products.Where(p => p.ProductId == productId).FirstOrDefault();
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }

        public void UpdateProduct(Product updateProduct)
        {

        }

        #endregion

        #region Categoires
        public IQueryable<Category> GetCategories()
        {
            return db.Categories;
        }

        #endregion

        #region Dropdowns


        public IQueryable GetDropDowns(string tblName, string valuefield, string textfield)
        {
            var result = db.Query(tblName).Select(string.Format("new ({0},{1}", valuefield, textfield));

            return (result);

        }

        public IEnumerable<SupplierDropDown> GetSupplierDropDown()
        {
            return (from c in db.Suppliers
                    select new SupplierDropDown { SupplierId = c.SupplierId.ToString(), CompanyName = c.CompanyName });
        }

        public IEnumerable<CategoryDropdown> GetCategoryDropdowns()
        {
            return (from c in db.Categories
                    select new CategoryDropdown { CategoryId = c.CategoryId.ToString(), CategoryName = c.CategoryName });
        }

        public IEnumerable<Product> GetDynamicProducts()
        {
            var result = db.Products.Where("ProductName Starts with 'P' OR SupplierId Is greater than '100' OR Discontinued Is equal to 'true'");
            return (result);
        }
        #endregion

        #region UserApplicationSettings
        public void AddUserSetting(UserSetting userSetting)
        {
            if (userSetting.SettingSeq == 0)
            {
                if (GetUserSettings(userSetting.UserId, userSetting.SettingKey).Count() > 0)
                {
                    userSetting.SettingSeq = GetUserSettings(userSetting.UserId, userSetting.SettingKey).Max(us => us.SettingSeq) + 1;
                }
                else
                {
                    userSetting.SettingSeq = 1;
                }

            }
            db.UserSettings.Add(userSetting);
            db.SaveChanges();
        }

        public IEnumerable<UserSetting> GetUserSettings(string userId, string userKey)
        {
            return (db.UserSettings.Where(m => m.UserId == userId && m.SettingKey.Equals(userKey)));
        }

        public UserSetting GetUserSetting(string userId, string userKey, int seq)
        {
            return (GetUserSettings(userId, userKey).Where(us => us.SettingSeq == seq).FirstOrDefault());
        }

        public UserSetting GetUserSetting(long rowId)
        {
            return (db.UserSettings.Where(us => us.Id == rowId).FirstOrDefault());
        }
        #endregion

    }



    public class SupplierDropDown
    {
        public string SupplierId { get; set; }
        public string CompanyName { get; set; }
    }

    public class CategoryDropdown
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

}
