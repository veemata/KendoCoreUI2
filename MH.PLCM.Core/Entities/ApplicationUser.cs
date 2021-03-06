﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MH.PLCM.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string ContactName { get; set; }
        public Company Company { get; set; }
        public Location Location { get; set; }
        public Department Department { get; set; }
        public ContributionLevel ContributionLevel { get; set; }

        [InverseProperty(nameof(AppUserRole.IdNavigation))]
        public virtual ICollection<AppUserRole> AppUserRoles { get; set; }
    }

    public enum Company
    {
        MHFT = 1,
        MPUS = 2
    }

    public enum Location
    {
        Division = 1,
        Allen = 2,
        Dillon = 3,
        Dixon = 4
    }

    public enum Department
    {
        Sales = 1,
        ProductManagement = 2,
        Engineering = 3,
        HDEngineering = 4,
        LDEngineering = 5,
        Packaging = 6,
        Artwork = 7,
        Quality = 8,
        MSS = 9
    }

    public enum ContributionLevel
    {
        Individaul = 1,
        Manager = 2
    }

}
