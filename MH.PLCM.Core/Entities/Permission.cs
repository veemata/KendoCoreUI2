using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MH.PLCM.Core.Entities
{
    public class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PermissionId { get; set; }

        [StringLength(100)]
        public string PermissionName { get; set; }

        [StringLength(100)]
        public string PermissionGroup { get; set; }

        [Required]
        [StringLength(150)]
        public string PermissionCode { get; set; }


        [StringLength(250)]
        public string Remarks { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }

    }
}
