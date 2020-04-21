using System;
using System.Collections.Generic;
using System.Text;

namespace MH.PLCM.Core.Entities
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }

        public List<AppMenuItem> MenuItems { get; set; }
    }
}
