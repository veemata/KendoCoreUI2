using Kendo.Mvc.UI;
using MH.PLCM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var root = (from p in _db.Permissions
                        where (p.PermissionParentId == 0)
                        select new TreeViewItemModel
                        {
                            Id = p.PermissionId.ToString(),
                            Text = p.PermissionName,
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
            var children = (from pc in _db.Permissions
                            where (pc.PermissionParentId == Convert.ToInt32(parent.Id))
                            select new TreeViewItemModel
                            {
                                Id = pc.PermissionId.ToString(),
                                Text = pc.PermissionName,
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


    }




}
