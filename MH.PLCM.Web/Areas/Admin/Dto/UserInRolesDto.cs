using MH.PLCM.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MH.PLCM.Models.Dtos
{
    public class UserInRolesDto
    {
        public ApplicationUser User { get; set; }
        public List<ApplicationUserRoleViewModel> Roles { get; set; }


    }


    public class ApplicationUserRoleViewModel
    {
        public int ApplicationRoleId { get; set; }
        [UIHint("DropDownRoles")]
        public ApplicationRoleViewModel ApplicationRoleViewModel { get; set; }

    }

    public class ApplicationRoleViewModel
    {
        public int ApplicationRoleId { get; set; }
        public string ApplicationRoleName { get; set; }
    }

}
