using Dynamic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MH.PLCM.Menu
{
    public static class DynamicMenu
    {

        public static string CreateSideMenu()
        {
            MenuItem i1 = new MenuItem();
            i1.MenuText = "Dashboard  <span class=\"badge badge-primary\">NEW</span>";
            i1.Url = "/Home/Index";
            i1.CssClassForIcon = "nav-icon icon-speedometer";

            return (GetTopMenuHtml(GetNavigableMenuItem(i1)));
        }
        public static string BuildMenuItems()
        {
            List<MenuItem> items = SampleMenu.GetMenuItems();
            StringBuilder sb = new StringBuilder();

            foreach (MenuItem itm in items.OrderBy(i => i.ParentId))
            {

                sb.AppendLine(GetNavigableMenuItem(itm));

                if (items.Where(c => c.ParentId == itm.ParentId).Count() > 0)
                {

                }
            }

            return (sb.ToString());
        }

        public static string GetTopMenuHtml(string menuItems)
        {
            TagBuilder sidebar = new TagBuilder("div");
            sidebar.AddCssClass("sidebar");

            TagBuilder nav = new TagBuilder("nav");
            nav.AddCssClass("sidebar-nav");

            TagBuilder ulist = new TagBuilder("ul");
            ulist.AddCssClass("nav");
            ulist.InnerHtml.AppendHtml(menuItems);
            ulist.RenderEndTag();

            nav.InnerHtml.AppendHtml(ulist.GetString());
            nav.RenderEndTag();

            sidebar.InnerHtml.AppendHtml(nav.GetString());
            sidebar.InnerHtml.AppendHtml("<button class=\"sidebar-minimizer brand-minimizer\" type=\"button\"></button>");
            sidebar.RenderEndTag();

            return (sidebar.GetString());

        }
        public static string GetNavigableMenuItem(MenuItem item)
        {
            TagBuilder list = new TagBuilder("li");
            list.AddCssClass("nav-tem");

            TagBuilder anchor = new TagBuilder("a");
            anchor.AddCssClass("nav-link");
            anchor.MergeAttribute("href", item.Url);

            TagBuilder icon = new TagBuilder("i");
            icon.AddCssClass(item.CssClassForIcon);
            icon.RenderEndTag();

            anchor.InnerHtml.AppendHtml(icon.GetString());
            anchor.InnerHtml.AppendHtml(item.MenuText);

            list.InnerHtml.AppendHtml(anchor.GetString());
            list.RenderEndTag();
            return list.GetString();
        }
        public static string GetDividerMenuItem()
        {
            TagBuilder tg = new TagBuilder("li");
            tg.AddCssClass("divider");
            tg.RenderEndTag();
            return tg.GetString();
        }
        public static string GetMenuWithChildItems(MenuItem item, List<MenuItem> children)
        {
            TagBuilder li = new TagBuilder("li");
            li.AddCssClass("nav-item nav-dropdown");

            TagBuilder a = new TagBuilder("a");
            a.AddCssClass("nav-link nav-dropdown-toggle");
            a.MergeAttribute("href", "#");

            TagBuilder i = new TagBuilder("i");
            i.AddCssClass(item.CssClassForIcon);
            i.RenderEndTag();

            a.InnerHtml.AppendHtml(i.GetString());
            a.InnerHtml.AppendHtml(item.MenuText);
            a.RenderEndTag();

            li.InnerHtml.AppendHtml(a.GetString());

            TagBuilder ul = new TagBuilder("ul");
            ul.AddCssClass("nav-dropdown-items");

            foreach (MenuItem itm in children)
            {
                ul.InnerHtml.AppendHtml(GetNavigableMenuItem(itm));
            }

            ul.RenderEndTag();

            li.InnerHtml.AppendHtml(ul.GetString());
            li.RenderEndTag();

            return li.GetString();

        }

    }

    public class SampleMenu
    {
        public static List<MenuItem> GetMenuItems()
        {
            List<MenuItem> items = new List<MenuItem>();

            //Dashoboard Item
            MenuItem dashboard = new MenuItem { Id = 1, MenuText = "Dashboard  <span class=\"badge badge-primary\">NEW</span>", Url = "/Home/Index", CssClassForIcon = "nav-icon icon-speedometer", ParentId = 0, Sequence = 1 };
            MenuItem colors = new MenuItem { Id = 2, MenuText = "Colors", Url = "/colors", CssClassForIcon = "nav-icon icon-drop", ParentId = 0, Sequence = 2 };
            MenuItem typography = new MenuItem { Id = 3, MenuText = "Colors", Url = "/typography", CssClassForIcon = "nav-icon icon-pencil", ParentId = 0, Sequence = 3 };

            // Parent with Children has no Url, but has css icon
            MenuItem baseItem = new MenuItem { Id = 4, MenuText = "Colors", CssClassForIcon = "nav-icon icon-puzzle", ParentId = 0, Sequence = 4 };
            MenuItem breadCrumb = new MenuItem { Id = 5, MenuText = "BreadCrumb", Url = "/base/breadcrumbs", CssClassForIcon = "nav-icon icon-puzzle", ParentId = 4, Sequence = 1 };
            MenuItem cards = new MenuItem { Id = 6, MenuText = "/base/cards", Url = "/base/cards", CssClassForIcon = "nav-icon icon-puzzle", ParentId = 4, Sequence = 2 };

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
