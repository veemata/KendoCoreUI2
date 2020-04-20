using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MH.PLCM
{
   
    public class Menu
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
    }

    public class MenuItem
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string MenuText { get; set; }
        [StringLength(255)]
        public string LinkUrl { get; set; }

        public string CssClassForIcon { get; set; }
        
        public int? MenuOrder { get; set; }
        public int? ParentMenuItemId { get; set; }
        public virtual MenuItem Parent { get; set; }
        
        public virtual ICollection<MenuItem> Children { get; set; }
        
        public int MenuId { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
