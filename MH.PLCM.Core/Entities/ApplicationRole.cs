using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MH.PLCM.Core.Entities
{

    public class ApplicationRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationRoleId { get; set; }

        [StringLength(100)]
        public string ApplicationRoleName { get; set; }

        public Permission Permission { get; set; }

        public ICollection<ApplicationUserRole> RoleUsers { get; set; }

        public ICollection<RolePermission> RolePermissions { set; get; }
    }
}
