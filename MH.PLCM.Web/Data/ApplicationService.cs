using Kendo.Mvc.UI;
using MH.PLCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MHMenu = MH.PLCM.Core.Entities.Menu;
using MHMenuItem = MH.PLCM.Core.Entities.AppMenuItem;

namespace MH.PLCM.Data
{
    public class ApplicationService
    {
        private readonly ApplicationDbContext _db;

        public ApplicationService(ApplicationDbContext db)
        {
            _db = db;
        }


        public IEnumerable<TreeViewItemModel> GetPermissionsTree()
        {
            var result = new List<TreeViewItemModel>();
            var root = (from p in _db.AppPermissions
                        where (p.ParentId == p.PermissionId)
                        select new TreeViewItemModel
                        {
                            Id = p.PermissionId.ToString(),
                            Text = p.Name,
                            Expanded = true,
                            Checked = true


                        }).SingleOrDefault();

            if (root != null)
            {
                AddChildren(root);
            }
            result.Add(root);

            return (result.AsEnumerable());
        }

        public void AddChildren(TreeViewItemModel parent)
        {
            var children = (from pc in _db.AppPermissions
                            where (pc.ParentId == Convert.ToInt32(parent.Id))
                            select new TreeViewItemModel
                            {
                                Id = pc.PermissionId.ToString(),
                                Text = pc.Name,
                                Expanded = true

                            }).ToList();
            if (children.Count > 0)
            {
                parent.HasChildren = true;
                parent.Items = children;

                foreach (var child in children)
                {
                    AddChildren(child);
                }
            }
        }

        public MHMenu GetMenuData()
        {
            MHMenu m = new Core.Entities.Menu { MenuId = 1, MenuName = "Root" };
            var allItems = _db.AppMenuItems.ToList();
            m.MenuItems = allItems.Where(mi => mi.ParentMenuItemId == 1).ToList();
            foreach (MHMenuItem mi in m.MenuItems)
            {
                PopulateChildren(mi, allItems);
            }
            return (m);
        }
        private  void PopulateChildren(MHMenuItem parent, List<MHMenuItem> all)
        {
            if (all.Where(ai => ai.ParentMenuItemId == parent.Id).Count() > 0)
            {
                parent.Children = all.Where(ai => ai.ParentMenuItemId == parent.Id).ToList();
                foreach (MHMenuItem mi in parent.Children)
                {
                    PopulateChildren(mi, all);
                }
            }

        }

    }




}
