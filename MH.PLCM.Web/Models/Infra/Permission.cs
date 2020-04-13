using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MH.PLCM.Models
{
    public class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PermissionId { get; set; }

        [StringLength(100)]
        public string PermissionName { get; set; }
        
        [StringLength(100)]
        public string  PermissionGroup { get; set; }  
        
        [Required]
        [StringLength(50)]
        public string ApplicationArea { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Controller { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Action { get; set; }

        [StringLength(250)]
        public string Remarks { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }

    }
}
