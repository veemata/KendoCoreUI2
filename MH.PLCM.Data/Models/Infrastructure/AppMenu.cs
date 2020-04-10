using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MH.PLCM.Northwind.Entities
{
    [Table("AppMenus")]
    public class AppMenu
    {
        [Key]
        public int Id { get; set; }
        public string MenuCodeName { get; set; }
        public string DisplayName { get; set; }
        public string NavigationUrl { get; set; }
        public string Icon { get; set; }
        public string PermissionDependency { get; set; }
        public int Sequence { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsVisible { get; set; }
        public int ParentId { get; set; }
        

    }
}
