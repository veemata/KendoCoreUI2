using MH.PLCM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MH.PLCM.Models.Dtos
{
    public class UserInRolesViewModel
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<ApplicationRole> Roles { get; set; }

    }
}
