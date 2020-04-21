using Dynamic;
using MH.PLCM.Core.Entities;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MH.PLCM
{
    public static class DynamicMenu
    {

        public static string RenderMenu(Menu menu)
        {
            StringBuilder sb = new StringBuilder();

            RenderMenuItems(menu.MenuItems, sb);
            RenderFullMenuWithChildItems(sb);
            RenderBottomCollapseMenu(sb);
            return (sb.ToString());
        }


        private static void RenderMenuItems(ICollection<AppMenuItem> items, StringBuilder sb)
        {
            foreach (AppMenuItem itm in items)
            {
                if (itm.LinkUrl.Equals("#") || string.IsNullOrEmpty(itm.LinkUrl))
                {
                    RenderDropdownBegin(itm, sb);
                }
                else
                {
                    RenderMenuItem(itm, sb);
                }
                if (itm.Children != null)
                {
                    RenderMenuItems(itm.Children, sb);
                    if (itm.LinkUrl.Equals("#") || string.IsNullOrEmpty(itm.LinkUrl))
                    {
                        EndDropdownMenu(sb);
                    }
                }
            }
        }

        //Assumes already child element html is appeded
        private static void RenderFullMenuWithChildItems(StringBuilder sb)
        {
            string subMenus = sb.ToString();
            sb.Clear();

            sb.AppendLine(string.Format(@" 
                            <nav class='sidebar-nav'>
                                <ul class='nav'>
                                   {0}
                                </ul>
                            </nav>", subMenus));


        }

        private static void RenderDropdownBegin(AppMenuItem item, StringBuilder sb)
        {
            sb.AppendLine((string.Format(@" 
                                <li class='nav-item nav-dropdown'>
                                        <a class='nav-link nav-dropdown-toggle' href='#'>
                                            <i class='{0}'></i> {1}
                                        </a>
                                 <ul class='nav-dropdown-items'>", item.CssClassForIcon, item.MenuText)));
        }

        private static void RenderMenuItem(AppMenuItem item, StringBuilder sb)
        {
            sb.AppendLine(string.Format(@"<li class='nav-item'>
                                       <a class='nav-link' href='{0}'>
                                        <i class='{1}'></i>{2}
                                       </a>
                                     </li>",
                                    item.LinkUrl,
                                    item.CssClassForIcon,
                                    item.MenuText));
        }
        private static void EndDropdownMenu(StringBuilder sb)
        {
            sb.AppendLine("</ul></li>");
        }

        private static void RenderBottomCollapseMenu(StringBuilder sb)
        {
            sb.AppendLine("<button class=\"sidebar-minimizer brand-minimizer\" type=\"button\"></button>");
        }
    }


}
