using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MH.PLCM.Models
{
    public class RolePermission
    {
        public int ApplicationRoleId { get; set; }
        public ApplicationRole ApplicationRole { get; set; }


        public int PermissionId { get; set; }  
        public Permission Permission { get; set; }
        

      
    }
}
