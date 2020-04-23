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

        public virtual DbSet<DynamicFeature> DynamicFeatures { get; set; }
        public virtual DbSet<DynamicItem> DynamicItems { get; set; }
        public virtual DbSet<DynamicItemFeature> DynamicItemFeatures { get; set; }
        public virtual DbSet<DynamicTemplate> DynamicTemplates { get; set; }
        public virtual DbSet<DynamicTemplateFeature> DynamicTemplateFeatures { get; set; }

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

            modelBuilder.Entity<DynamicFeature>(entity =>
            {
                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.DataTypeId).HasDefaultValueSql("((1))");

                entity.Property(e => e.DefaultValue)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.LookupId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ResponsibleGroupId).HasComment("Lookup 1041");

                entity.Property(e => e.UnitOfMeasure)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<DynamicItem>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_DynamicItem");
            });

            modelBuilder.Entity<DynamicItemFeature>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_DynamicPackaging");

                entity.HasIndex(e => new { e.ItemRowId, e.FeatureRowId })
                    .HasName("IX_DynamicItemFeatures")
                    .IsUnique();

                entity.Property(e => e.Comments)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FeatureValue).IsUnicode(false);

                entity.HasOne(d => d.FeatureRow)
                    .WithMany(p => p.DynamicItemFeatures)
                    .HasForeignKey(d => d.FeatureRowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DynamicPackaging_DynamicFeatures");

                entity.HasOne(d => d.ItemRow)
                    .WithMany(p => p.DynamicItemFeatures)
                    .HasForeignKey(d => d.ItemRowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DynamicPackaging_DynamicItem");
            });

            modelBuilder.Entity<DynamicTemplate>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_Templates");

                entity.HasIndex(e => e.TemplateName)
                    .HasName("IX_DynamicTemplates")
                    .IsUnique();

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.TemplateName).IsUnicode(false);
            });

            modelBuilder.Entity<DynamicTemplateFeature>(entity =>
            {
                entity.HasIndex(e => new { e.TemplateRowId, e.FeatureRowId })
                    .HasName("IX_DynamicTemplateFeatures")
                    .IsUnique();

                entity.Property(e => e.FeatureValue)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.TemplateRow)
                    .WithMany(p => p.DynamicTemplateFeatures)
                    .HasForeignKey(d => d.TemplateRowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DynamicTemplateFeatures_DynamicTemplates");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}