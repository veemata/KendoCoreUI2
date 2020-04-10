﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MH.PLCM.Models
{
    [Table("NACO_NewPart")]
    public partial class NacoNewPart
    {
        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string PartNumber { get; set; }
        [StringLength(500)]
        public string ItemDescription { get; set; }
        [StringLength(50)]
        public string PurchaseMenu { get; set; }
        [StringLength(50)]
        public string ToolingCost { get; set; }
        public bool? ToolingOrdered { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ToolingOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ToolingDueDateOn { get; set; }
        public int? PpapLevel { get; set; }
        public int? PpapQty { get; set; }
        public bool? Complete { get; set; }
        public bool? PrintComplete { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PrintCompletedOn { get; set; }
        public bool? PrintReleased { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PrintReleasedOn { get; set; }
        public bool? ProductCode { get; set; }
        public int? IsActive { get; set; }
        [Column("NPrev")]
        [StringLength(5)]
        public string Nprev { get; set; }
        [Column("NPsheet")]
        [StringLength(5)]
        public string Npsheet { get; set; }
        [StringLength(255)]
        public string DrawingFile { get; set; }
    }
}