using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MH.PLCM
{
    public static class SampleMenu
    {

        public static Menu GetMenuData()
        {
            Menu m = new Menu();
            m.MenuId = 1;
            m.MenuName = "Main Menu";
            var allItems = GetAllMenuItems();
            m.MenuItems = allItems.Where(mi => mi.ParentMenuItemId == 0).ToList();     
            foreach(MenuItem mi in m.MenuItems)
            {
                PopulateChildren(mi, allItems);
            }

            return (m);
        }

        public static void PopulateChildren(MenuItem parent, List<MenuItem> all)
        {
            if(all.Where(ai=>ai.ParentMenuItemId == parent.Id).Count() >0)
            {
                parent.Children = all.Where(ai => ai.ParentMenuItemId == parent.Id).ToList();
                foreach(MenuItem mi in parent.Children)
                {
                    PopulateChildren(mi, all);
                }
            }
            
        }
        public static List<MenuItem> GetAllMenuItems()
        {
            List<MenuItem> items = new List<MenuItem>();

            //Dashoboard Item
            MenuItem dashboard = new MenuItem { Id = 1, MenuText = "Dashboard  <span class=\"badge badge-primary\">NEW</span>", LinkUrl = "/Home/Index", CssClassForIcon = "nav-icon icon-speedometer", ParentMenuItemId = 0, MenuOrder = 1 };
            MenuItem colors = new MenuItem { Id = 2, MenuText = "Colors", LinkUrl = "/colors", CssClassForIcon = "nav-icon icon-drop", ParentMenuItemId = 0, MenuOrder = 2 };
            MenuItem typography = new MenuItem { Id = 3, MenuText = "Typography", LinkUrl = "/typography", CssClassForIcon = "nav-icon icon-pencil", ParentMenuItemId = 0, MenuOrder = 3 };

            // Parent with Children has no Url, but has css icon
            MenuItem baseItem = new MenuItem { Id = 4, MenuText = "Parent", CssClassForIcon = "nav-icon icon-puzzle", ParentMenuItemId = 0, MenuOrder = 4 };
            MenuItem breadCrumb = new MenuItem { Id = 5, MenuText = "Child1", LinkUrl = "/base/breadcrumbs", CssClassForIcon = "nav-icon icon-puzzle", ParentMenuItemId = 4, MenuOrder = 1};
            MenuItem cards = new MenuItem { Id = 6, MenuText = "Child2", LinkUrl = "/base/cards", CssClassForIcon = "nav-icon icon-puzzle", ParentMenuItemId = 4, MenuOrder = 2 };

            items.Add(dashboard);
            items.Add(colors);
            items.Add(typography);
            items.Add(baseItem);
            items.Add(breadCrumb);
            items.Add(cards);

            return (items);
        }
    }
}
