using System;
using System.Collections.Generic;
using System.Text;
using MH.PLCM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MH.PLCM.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {

        public virtual DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }

        public virtual DbSet<NacoEngArtworkRequest> NacoEngArtworkRequests { get; set; }
        public virtual DbSet<NacoEngArtworkRequestPlate> NacoEngArtworkRequestPlates { get; set; }
        public virtual DbSet<NacoEngineering> NacoEngineerings { get; set; }
        public virtual DbSet<NacoFilter> NacoFilters { get; set; }
        public virtual DbSet<NacoHistory> NacoHistories { get; set; }
        public virtual DbSet<NacoMss> NacoMsses { get; set; }
        public virtual DbSet<NacoNewPart> NacoNewParts { get; set; }
        public virtual DbSet<NacoPackaging> NacoPackagings { get; set; }
        public virtual DbSet<NacoPackagingValImage> NacoPackagingValImages { get; set; }
        public virtual DbSet<NacoQuality> NacoQualities { get; set; }
        public virtual DbSet<NacoTrigger> NacoTriggers { get; set; }
        public virtual DbSet<NacoValidation> NacoValidations { get; set; }




        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationRole>().HasIndex(ar => ar.ApplicationRoleName).IsUnique();
            modelBuilder.Entity<Permission>().HasIndex(p => p.PermissionName).IsUnique();

            // Many to Many Relation Ship Linking
            modelBuilder.Entity<RolePermission>().HasKey(x => new { x.ApplicationRoleId, x.PermissionId });

         

            modelBuilder.Entity<NacoEngArtworkRequestPlate>(entity =>
            {
                entity.HasOne(d => d.ArkworkRequest)
                    .WithMany(p => p.NacoEngArtworkRequestPlates)
                    .HasForeignKey(d => d.ArkworkRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NACO_EngArtworkRequestPlate_NACO_EngArtworkRequest");
            });

            modelBuilder.Entity<NacoEngineering>(entity =>
            {
                entity.Property(e => e.CountryOfOrigin).HasDefaultValueSql("('')");

                entity.Property(e => e.IsPpaprequired).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsPurchasedProduct).HasDefaultValueSql("((1))");

                entity.Property(e => e.ManufacturerPartNumber).IsUnicode(false);
            });

            modelBuilder.Entity<NacoFilter>(entity =>
            {
                entity.Property(e => e.IdmethodId).HasDefaultValueSql("('None')");

                entity.Property(e => e.InnerDiameterLabelPartNo).HasDefaultValueSql("('')");

                entity.Property(e => e.MasterPlatePartNo).HasDefaultValueSql("('')");

                entity.Property(e => e.PrintPlate1PartNo).HasDefaultValueSql("('')");

                entity.Property(e => e.PrintPlate2PartNo).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<NacoHistory>(entity =>
            {
                entity.Property(e => e.ChangeDescription).IsUnicode(false);

                entity.Property(e => e.Filename).IsUnicode(false);
            });

            modelBuilder.Entity<NacoNewPart>(entity =>
            {
                entity.Property(e => e.DrawingFile).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Nprev).IsUnicode(false);

                entity.Property(e => e.Npsheet).IsUnicode(false);
            });

            modelBuilder.Entity<NacoPackaging>(entity =>
            {
                entity.Property(e => e.OtherPackaging).IsUnicode(false);
            });

            modelBuilder.Entity<NacoTrigger>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Department).IsUnicode(false);

                entity.Property(e => e.LastReminderOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RemindDays).HasDefaultValueSql("((3))");

                entity.Property(e => e.What).HasDefaultValueSql("('')");
            }); 
        }

    }
}
