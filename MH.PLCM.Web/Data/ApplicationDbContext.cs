using MH.PLCM.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MH.PLCM.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {

        public virtual DbSet<ApplicationUserRole> UserApplicationRoles { get; set; }
        public virtual DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }

        public virtual DbSet<MenuItem> Menus { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationRole>().HasIndex(ar => ar.ApplicationRoleName).IsUnique();
            modelBuilder.Entity<Permission>().HasIndex(p => p.PermissionName).IsUnique();

            // Many to Many Relationship between Role and Permissions Linking
            modelBuilder.Entity<RolePermission>().HasKey(x => new { x.ApplicationRoleId, x.PermissionId });
            //Many to Many relationship between User and Roles
            modelBuilder.Entity<ApplicationUserRole>().HasKey(x => new { x.UserId, x.ApplicationRoleId });

        }

    }
}
