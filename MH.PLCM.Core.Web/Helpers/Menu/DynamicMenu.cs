using Dynamic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MH.PLCM
{
    public static class DynamicMenu
    {

        public static string BuildMenuItems()
        {
            Menu m = SampleMenu.GetMenuData();
            StringBuilder sb = new StringBuilder();

            // not rendering  </li> </ ul > after end of parent menu

            RenderMenuItems(m.MenuItems, sb);
            RenderFullMenuWithChildItems(sb);
            RenderBottomCollapseMenu(sb);
            return (sb.ToString());
        }


        public static void RenderMenuItems(ICollection<MenuItem> items, StringBuilder sb)
        {
            foreach (MenuItem itm in items)
            {
                if (string.IsNullOrEmpty(itm.LinkUrl))
                {
                    sb.AppendLine(BeginDropdownMenu(itm));
                }
                else
                {
                    sb.AppendLine(RenderMenuItem(itm));
                }
                if(itm.Children != null )
                {
                    RenderMenuItems(itm.Children, sb);
                }
                else if (string.IsNullOrEmpty(itm.LinkUrl))
                {
                    sb.AppendLine(EndDropdownMenu().ToString());
                }
            }
        }

        //Assumes already child element html is appeded
        public static void RenderFullMenuWithChildItems(StringBuilder sb)
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

        public static string BeginDropdownMenu(MenuItem item)
        {
            return (string.Format(@" 
                                <li class='nav-item nav-dropdown'>
                                        <a class='nav-link nav-dropdown-toggle' href='#'>
                                            <i class='{0}'></i> {1}
                                        </a>
                                 <ul class='nav-dropdown-items'>", item.CssClassForIcon, item.MenuText));
        }

        public static string RenderMenuItem(MenuItem item)
        {
            return (string.Format(@"<li class='nav-item'>
                                       <a class='nav-link' href='{0}'>
                                        <i class='{1}'></i>{2}
                                       </a>
                                     </li>",
                                    item.LinkUrl,
                                    item.CssClassForIcon,
                                    item.MenuText));
        }
        public static HtmlString EndDropdownMenu()
        {
            return (new HtmlString("</ul></li>"));
        }

        public static void RenderBottomCollapseMenu(StringBuilder sb)
        {
            sb.AppendLine("<button class=\"sidebar-minimizer brand-minimizer\" type=\"button\"></button>");
        }
    }


}
