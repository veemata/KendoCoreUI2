using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MH.PLCM.Models
{
   
    public class ApplicationRole 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationRoleId { get; set; }

        [StringLength(100)]
        public string ApplicationRoleName { get; set; }

        public Permission Permission { get; set; }

        public  ICollection<RolePermission> RolePermissions { set; get; }
    }
}
