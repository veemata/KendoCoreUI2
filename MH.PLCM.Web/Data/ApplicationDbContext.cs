using System;
using MH.PLCM.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace MH.PLCM.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppMenuItem> AppMenuItems { get; set; }
        public virtual DbSet<AppPermission> AppPermissions { get; set; }
        public virtual DbSet<AppRole> AppRoles { get; set; }
        public virtual DbSet<AppRolePermission> AppRolePermissions { get; set; }
        public virtual DbSet<AppUserRole> AppUserRoles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppMenuItem>(entity =>
            {
                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK_AppMenuItems_AppMenuItems");
            });

            modelBuilder.Entity<AppPermission>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .IsUnique()
                    .HasFilter("([Name] IS NOT NULL)");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_AppPermissions_AppPermissions");
            });

            modelBuilder.Entity<AppRole>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .IsUnique()
                    .HasFilter("([Name] IS NOT NULL)");
            });

            modelBuilder.Entity<AppRolePermission>(entity =>
            {
                entity.HasKey(e => new { e.AppRoleId, e.PermissionId });

                entity.HasIndex(e => e.PermissionId);
            });

            modelBuilder.Entity<AppUserRole>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.AppRoleId });

                entity.HasIndex(e => e.AppRoleId)
                    .HasName("IX_AppUserRole_RoleId");

                entity.HasOne(d => d.AppRole)
                    .WithMany(p => p.AppUserRoles)
                    .HasForeignKey(d => d.AppRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppUserRole_AppRoles");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.AppUserRoles)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppUserRole_AspNetUsers");
            });
   

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}