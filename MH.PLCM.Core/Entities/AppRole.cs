﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MH.PLCM.Core.Entities
{
    public partial class AppRole
    {
        public AppRole()
        {
            AppRolePermissions = new HashSet<AppRolePermission>();
            AppUserRoles = new HashSet<AppUserRole>();
        }

        [Key]
        public int AppRoleId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Remarks { get; set; }

        [InverseProperty(nameof(AppRolePermission.AppRole))]
        public virtual ICollection<AppRolePermission> AppRolePermissions { get; set; }
        [InverseProperty(nameof(AppUserRole.AppRole))]
        public virtual ICollection<AppUserRole> AppUserRoles { get; set; }
    }
}